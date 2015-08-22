using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using GBERP.ViewModel;

namespace GBERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public ViewModel.MainWindow VM;
        public AF.RibbonManager _ribMgr;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VM = this.DataContext as ViewModel.MainWindow;
            VM.CurrentPageVM = VM;
            _ribMgr = new AF.RibbonManager(VM.PageID, ribMain);
            AF.Environment.FactoryID = "T1";
            AF.Environment.Identity = new Model.Identity()
            {
                Account = "x",
                DptID = "000",
                DptName = "IT",
                EmpID = "00083996",
                Name = "Scott"
            };
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (Model.MenuItem)tv1.SelectedValue;
            if (selectedItem.ChildNodes != null && selectedItem.ChildNodes.Count > 0)
                return;

            e.Handled = true;
            foreach (TabItem item in tabMain.Items)
            {
                if (item.Tag != null && item.Tag.ToString() == selectedItem.MenuID)
                {
                    SelectTabItem(item);
                    return;
                }
            }

            UserControl v = OpenNewPage(selectedItem.Url, selectedItem.MenuName, selectedItem.MenuID);
            if (v == null)
            {
                var errMsg = "Invalid url of MenuID '" + selectedItem.MenuID + "'";
                Utils.ErrorLog.Current.AppendLog(errMsg);
                TipsMessagePopup.SimpleShow(this,errMsg);
            }
        }

        public UserControl OpenNewPage(string path, string title, string tag = null)
        {
            var v = (UserControl)AF.Reflection.Create(path);
            string errMsg;
            if (v == null)
            {
                errMsg = "Open new page of path '" + path + "' failed.";
                Utils.ErrorLog.Current.AppendLog(errMsg);
                return v;
            }
            var tabItem = new Model.ClosableTabItem();
            tabItem.Title = title;
            tabItem.Content = v;
            tabItem.Tag = tag;
            tabMain.Items.Add(tabItem);
            SelectTabItem(tabItem);

            var vdc = (ViewModel.ViewModelBase)v.DataContext;
            VM.CurrentPageVM = vdc;
            _ribMgr.LoadRibbon(vdc);
            return v;
        }

        void SelectTabItem(TabItem item)
        {
            Dispatcher.InvokeAsync(() =>
            {
                item.IsSelected = true;
              
            });
        }
        
    }
}
