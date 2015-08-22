using GBERP.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GBERP.ViewModel
{
    public class MainWindow : ViewModelBase
    {
        public ViewModelBase CurrentPageVM { get; set; }

        private List<Model.MenuItem> _menus;
        public List<Model.MenuItem> Menus
        {
            get
            {
                if (_menus == null)
                {
                    _menus = new List<Model.MenuItem>();
                    Task.Run(() =>
                    {
                        LoadMenus();
                    });

                }
                return _menus;
            }
            set
            {
                _menus = value;
                NotifyPropertyChanged("Menus");
            }
        }

        private int _tabSelectedIndex;
        public int TabSelectedIndex
        {
            get
            {
                return _tabSelectedIndex;
            }
            set
            {
                _tabSelectedIndex = value;
                NotifyPropertyChanged("TabSelectedIndex");
            }
        }

        public ICommand RibbonCommand
        {
            get
            {
                return new RelayCommand(
                    cmdName =>
                    {
                        CurrentPageVM.TryExecuteCommand(cmdName.ToString());
                    }
                );
            }
        }

        private void LoadMenus()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM, "wcm_LoadMenu");
            if (!qr.Result)
            {
                var errMsg = "An error occured while load menus:" + qr.Message;
                Utils.ErrorLog.Current.AppendLog(errMsg);
                App.Alert(errMsg);
                return;
            }
            var menus = qr.Output1.AsEnumerable().Select(p => new Model.MenuItem()
                {
                    MenuID = p.Field<string>(0),
                    ModuleID = p.Field<string>(1),
                    MenuName = p.Field<string>(2),
                    SupMenuID = p.Field<string>(3),
                    Url = p.Field<string>(4)
                }).ToList();
            var rootMenus = menus.Where(p => string.IsNullOrEmpty(p.SupMenuID)).ToList();
            foreach (var rm in rootMenus)
                CreateChildren(rm, menus);
            Menus = rootMenus;
        }

        private void CreateChildren(Model.MenuItem parent, List<Model.MenuItem> menus)
        {
            parent.ChildNodes = menus.Where(p => p.SupMenuID == parent.MenuID).ToList();
            foreach (var cn in parent.ChildNodes)
                CreateChildren(cn, menus);
        }

    }
}
