using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Ribbon;
using System.Windows.Markup;
using System.Xml.Linq;

namespace GBERP.AF
{
    /*RibbonManager 功能设计:
     * 允许各页面动态创建各自的私有RibbonTab页.
     * 当页面发生切换时,RibbonManager能够自动隐藏上一个页面的RibbonTab,激活新页面的RibbonTab
     * 当页面被关闭时,销毁该页面的私有RibbonTab.
     * 
     * 公共的RibbonTab模板,允许修改
     */
    public class RibbonManager
    {
        //主ribbon控件
        private Ribbon _rib;
        //key是pageID, 值是这个页面所对应的一组ribbonTab
        Dictionary<int, List<RibbonTab>> _ribTabs;
        //默认的ribbontabs, key是header.
        Dictionary<string, RibbonTab> _defaultTabs;
        //当前页面的pageID
        private int _currentPageID;
        //默认页面的pageID.
        private int _defaultPageID;

        public RibbonManager(int pageID, Ribbon rib)
        {
            _rib = rib;
            _ribTabs = new Dictionary<int, List<RibbonTab>>();
            var defaultTabs = new List<RibbonTab>();
            foreach (RibbonTab rt in _rib.Items)
                defaultTabs.Add(rt);
            _ribTabs.Add(pageID, defaultTabs);
            _defaultPageID = pageID;
            _defaultTabs=defaultTabs.ToDictionary(k => k.Header.ToString(), v => v);
        }

        public Model.ReturnValue LoadRibbon(ViewModel.ViewModelBase vm)
        {
            var pageID = vm.PageID;
            var path = vm.Path;
            var rv = new Model.ReturnValue();
            var realPath=ResourceFile.MapXMLPath(path, "Ribbon");
            if(!ResourceFile.Exists(realPath))
            {
                rv.Result = false;
                rv.Message = "file does not exist.";
                return rv;
            }
            var root = XDocument.Load(System.Windows.Application.GetResourceStream(
                new Uri(realPath)).Stream).Root;
            var tabs = root.Elements("RibbonTab");

            List<RibbonTab> pageTabs;
            if (_ribTabs.ContainsKey(pageID))
                pageTabs = _ribTabs[pageID];
            else
            {
                pageTabs = new List<RibbonTab>();
                _ribTabs.Add(pageID, pageTabs);
            }
            foreach (var xt in tabs)
            {
                var rt = CreateRibbonTab(xt);
                var rtHeader = rt.Header.ToString();
                //子页面与子页面之间的header允许重复
                //但是任何一个子页面的header 不能与默认页面的header重复.
                //所以, 当遇到与默认页面header重复时, 认为是在覆盖默认tab
                if (_defaultTabs.ContainsKey(rtHeader))
                {
                    if (rt.Tag != null && rt.Tag.ToString().ToLower() == "overwrite")
                        _defaultTabs[rtHeader].Items.Clear();
                    while (rt.Items.Count > 0)
                    {
                        var rg = rt.Items[0];
                        rt.Items.Remove(rg);
                        _defaultTabs[rtHeader].Items.Add(rg);
                    }

                    if (rt.IsSelected)
                        _defaultTabs[rtHeader].IsSelected = true;
                }
                else
                {
                    _rib.Items.Add(rt);
                    pageTabs.Add(rt);
                }

            }
            return rv;
        }

        private RibbonTab CreateRibbonTab(XElement xe)
        {
            ParserContext context = new ParserContext();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            UpdateImageSource(xe);
            using (var ms = new System.IO.MemoryStream())
            {
                xe.Save(ms);
                ms.Position = 0;
                return (RibbonTab)XamlReader.Load(ms, context);
            }
        }

        private string BuildErrorMessage(string path, string msg)
        {
            return "Load ribbon settings fail for path '" + path + "', error message:" + msg;
        }

        private void SwitchPage(int pageID)
        {

        }

        private void UpdateImageSource(XElement xe)
        {
            var xa = xe.Attribute("LargeImageSource");
            if (xa != null)
                xa.Value = "pack://application:,,,/GBERP;component/" + xa.Value;
            xa = xe.Attribute("SmallImageSource");
            if (xa != null)
                xa.Value = "pack://application:,,,/GBERP;component/" + xa.Value;
            foreach (var sxe in xe.Elements())
                UpdateImageSource(sxe);
        }

    }
}
