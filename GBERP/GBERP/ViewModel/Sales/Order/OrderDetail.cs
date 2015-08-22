using GBERP.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GBERP.ViewModel.Sales.Order
{
    public class OrderDetail : ViewModelBase
    {
        public OrderDetail()
        {

            InitControl();
        }

        #region " Properties "

        private bool _isJjdd;
        /// <summary>
        /// 是否紧急订单
        /// </summary>
        public bool IsJjdd
        {
            get
            {
                return _isJjdd;
            }
            set
            {
                _isJjdd = value;
                NotifyPropertyChanged("IsJjdd");
            }
        }

        private bool _isYpdd;
        /// <summary>
        /// 是否样品订单
        /// </summary>
        public bool IsYpdd
        {
            get
            {
                return _isYpdd;
            }
            set
            {
                _isYpdd = value;
                NotifyPropertyChanged("IsYpdd");
            }
        }

        private List<TextValuePair> _listBhfs;
        /// <summary>
        /// 备货方式列表
        /// </summary>
        public List<TextValuePair> ListBhfs
        {
            get
            {
                return _listBhfs;
            }
            set
            {
                _listBhfs = value;
                NotifyPropertyChanged("ListBhfs");
            }
        }

        private List<TextValuePair> _listCjfs;
        /// <summary>
        /// 成交方式列表
        /// </summary>
        public List<TextValuePair> ListCjfs
        {
            get
            {
                return _listCjfs;
            }
            set
            {
                _listCjfs = value;
                NotifyPropertyChanged("ListCjfs");
            }
        }

        private List<TextValuePair> _listDdly;
        /// <summary>
        /// 订单来源列表
        /// </summary>
        public List<TextValuePair> ListDdly
        {
            get
            {
                return _listDdly;
            }
            set
            {
                _listDdly = value;
                NotifyPropertyChanged("ListDdly");
            }
        }

        private List<TextValuePair> _listKpyq;
        /// <summary>
        /// 开票要求列表
        /// </summary>
        public List<TextValuePair> ListKpyq
        {
            get
            {
                return _listKpyq;
            }
            set
            {
                _listKpyq = value;
                NotifyPropertyChanged("ListKpyq");
            }
        }

        private List<TextValuePair> _listSccj;
        /// <summary>
        /// 生产车间列表
        /// </summary>
        public List<TextValuePair> ListSccj
        {
            get
            {
                return _listSccj;
            }
            set
            {
                _listSccj = value;
                NotifyPropertyChanged("ListSccj");
            }
        }

        private List<TextValuePair> _listThyt;
        /// <summary>
        /// 提货用途列表
        /// </summary>
        public List<TextValuePair> ListThyt
        {
            get
            {
                return _listThyt;
            }
            set
            {
                _listThyt = value;
                NotifyPropertyChanged("ListThyt");
            }
        }

        private List<TextValuePair> _listXdgc;
        /// <summary>
        /// 下达工厂列表
        /// </summary>
        public List<TextValuePair> ListXdgc
        {
            get
            {
                return _listXdgc;
            }
            set
            {
                _listXdgc = value;
                NotifyPropertyChanged("ListXdgc");
            }
        }

        private List<TextValuePair> _listXwgj;
        /// <summary>
        /// 销往国家列表
        /// </summary>
        public List<TextValuePair> ListXwgj
        {
            get
            {
                return _listXwgj;
            }
            set
            {
                _listXwgj = value;
                NotifyPropertyChanged("ListXwgj");
            }
        }

        private List<TextValuePair> _listYsfs;
        /// <summary>
        /// 运输方式列表
        /// </summary>
        public List<TextValuePair> ListYsfs
        {
            get
            {
                return _listYsfs;
            }
            set
            {
                _listYsfs = value;
                NotifyPropertyChanged("ListYsfs");
            }
        }

        private List<TextValuePair> _listYwy;
        /// <summary>
        /// 业务员列表
        /// </summary>
        public List<TextValuePair> ListYwy
        {
            get
            {
                return _listYwy;
            }
            set
            {
                _listYwy = value;
                NotifyPropertyChanged("ListYwy");
            }
        }

        private List<TextValuePair> _listYwbm;
        /// <summary>
        /// 业务部门列表
        /// </summary>
        public List<TextValuePair> ListYwbm
        {
            get
            {
                return _listYwbm;
            }
            set
            {
                _listYwbm = value;
                NotifyPropertyChanged("ListYwbm");
            }
        }

        private List<TextValuePair> _listZdch;
        /// <summary>
        /// 组单出货列表
        /// </summary>
        public List<TextValuePair> ListZdch
        {
            get
            {
                return _listZdch;
            }
            set
            {
                _listZdch = value;
                NotifyPropertyChanged("ListZdch");
            }
        }

        private string _selectedBhfsbh;
        /// <summary>
        /// 当前选中的备货方式编号
        /// </summary>
        public string SelectedBhfsbh
        {
            get
            {
                return _selectedBhfsbh;
            }
            set
            {
                _selectedBhfsbh = value;
                NotifyPropertyChanged("SelectedBhfsbh");
            }
        }

        private string _selectedCjfsbh;
        /// <summary>
        /// 当前选中的成交方式编号
        /// </summary>
        public string SelectedCjfsbh
        {
            get
            {
                return _selectedCjfsbh;
            }
            set
            {
                _selectedCjfsbh = value;
                NotifyPropertyChanged("SelectedCjfsbh");
            }
        }

        private string _selectedDdlybh;
        /// <summary>
        /// 当前选中的订单来源编号
        /// </summary>
        public string SelectedDdlybh
        {
            get
            {
                return _selectedDdlybh;
            }
            set
            {
                _selectedDdlybh = value;
                NotifyPropertyChanged("SelectedDdlybh");
            }
        }

        private string _selectedKpyqbh;
        /// <summary>
        /// 当前选中的开票要求编号
        /// </summary>
        public string SelectedKpyqbh
        {
            get
            {
                return _selectedKpyqbh;
            }
            set
            {
                _selectedKpyqbh = value;
                NotifyPropertyChanged("SelectedKpyqbh");
            }
        }

        private string _selectedSccjbh;
        /// <summary>
        /// 当前选中的生产车间编号
        /// </summary>
        public string SelectedSccjbh
        {
            get
            {
                return _selectedSccjbh;
            }
            set
            {
                _selectedSccjbh = value;
                NotifyPropertyChanged("SelectedSccjbh");
            }
        }

        private string _selectedThytbh;
        /// <summary>
        /// 当前选中的提货用途编号
        /// </summary>
        public string SelectedThytbh
        {
            get
            {
                return _selectedThytbh;
            }
            set
            {
                _selectedThytbh = value;
                NotifyPropertyChanged("SelectedThytbh");
            }
        }

        private string _selectedXdgcbh;
        /// <summary>
        /// 当前选中的下达工厂编号
        /// </summary>
        public string SelectedXdgcbh
        {
            get
            {
                return _selectedXdgcbh;
            }
            set
            {
                _selectedXdgcbh = value;
                NotifyPropertyChanged("SelectedXdgcbh");
            }
        }

        private string _selectedXwgjbh;
        /// <summary>
        /// 当前选中的销往国家编号
        /// </summary>
        public string SelectedXwgjbh
        {
            get
            {
                return _selectedXwgjbh;
            }
            set
            {
                _selectedXwgjbh = value;
                NotifyPropertyChanged("SelectedXwgjbh");
            }
        }

        private string _selectedYsfsbh;
        /// <summary>
        /// 当前选中的运输方式编号
        /// </summary>
        public string SelectedYsfsbh
        {
            get
            {
                return _selectedYsfsbh;
            }
            set
            {
                _selectedYsfsbh = value;
                NotifyPropertyChanged("SelectedYsfsbh");
            }
        }

        private string _selectedYwbmbh;
        /// <summary>
        /// 当前选中的业务员编号
        /// </summary>
        public string SelectedYwbmbh
        {
            get
            {
                return _selectedYwbmbh;
            }
            set
            {
                _selectedYwbmbh = value;
                NotifyPropertyChanged("SelectedYwbmbh");
            }
        }

        private string _selectedYwybh;
        /// <summary>
        /// 当前选中的业务员编号
        /// </summary>
        public string SelectedYwybh
        {
            get
            {
                return _selectedYwybh;
            }
            set
            {
                _selectedYwybh = value;
                NotifyPropertyChanged("SelectedYwybh");
                LoadYwbm();
            }
        }

        private string _selectedZdchbh;
        /// <summary>
        /// 当前选中的组单出货编号
        /// </summary>
        public string SelectedZdchbh
        {
            get
            {
                return _selectedZdchbh;
            }
            set
            {
                _selectedZdchbh = value;
                NotifyPropertyChanged("SelectedZdchbh");
            }
        }

        private DateTime _khxdrq;
        public DateTime Khxdrq
        {
            get
            {
                return _khxdrq;
            }
            set
            {
                _khxdrq = value;
                NotifyPropertyChanged("Khxdrq");
            }
        }

        #region " Commands "

        public ICommand Insert
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        App.Alert("insert");
                    }
                );
            }
        }

        public ICommand Query
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        App.Alert("Query");
                    }
                );
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        App.Alert("save");
                    }
                );
            }
        }

        public ICommand SelectCustomer
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        AF.DataSelect.DataSelectSingle("选择客户");
                    }
                );
            }
        }

        public ICommand Submit
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        App.Alert("submit");
                    }
                );
            }
        }

        #endregion

        #endregion

        #region " Functions "

        void InitControl()
        {
            Task.Run(() =>
            {
                Khxdrq = DateTime.Now;
                LoadYwy();
                LoadXwgj();
                LoadDdly();
                LoadCjfs();
                LoadKpyq();
                LoadBhfs();
                LoadZdch();
                LoadThyt();
                LoadXdgc();
                LoadSccj();
                LoadYsfs();
                IsJjdd = false;
                IsYpdd = false;
            });

        }

        void LoadBhfs()
        {
            ListBhfs = new List<TextValuePair>()
            {
                new TextValuePair("下达生产","1"),
                new TextValuePair("库存备货","2")
            };
            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListBhfs", ListBhfs);
            if (rv.Result)
                SelectedBhfsbh = rv.Output1;
        }

        void LoadCjfs()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadCjfs");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListCjfs = qr.Output1
                .AsEnumerable()
                .Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();

            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListCjfs", ListCjfs);
            if (rv.Result)
                SelectedCjfsbh = rv.Output1;
        }

        void LoadDdly()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadDdly");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListDdly = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();

            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListDdly", ListDdly);
            if (rv.Result)
                SelectedDdlybh = rv.Output1;
        }

        void LoadKpyq()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadKpyq");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListKpyq = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();

            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListKpyq", ListKpyq);
            if (rv.Result)
                SelectedKpyqbh = rv.Output1;
        }

        /// <summary>
        /// 加载 生产车间
        /// </summary>
        void LoadSccj()
        {
            ListSccj = new List<TextValuePair>()
            {
                new TextValuePair("一车间","T1"),
                new TextValuePair("二车间","T2"),
                new TextValuePair("三车间","T3"),
            };

            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListSccj", ListSccj);
            if (rv.Result)
                SelectedSccjbh = rv.Output1;
        }

        /// <summary>
        /// 加载 提货用途
        /// </summary>
        void LoadThyt()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadThyt");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListThyt = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();

            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListThyt", ListThyt);
            if (rv.Result)
                SelectedThytbh = rv.Output1;
        }

        void LoadXdgc()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadXdgc",
                new Dictionary<string, string>()
                {
                    {"factoryID",AF.Environment.FactoryID}
                });
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListXdgc = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();

            var selectedItem = ListXdgc.FirstOrDefault(p => p.Value == AF.Environment.FactoryID);
            if (selectedItem != null)
                SelectedXdgcbh = selectedItem.Value;
        }

        void LoadXwgj()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadXwgj");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListXwgj = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();
        }

        void LoadYsfs()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadYsfs");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListYsfs = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();
            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListYsfs", ListYsfs);
            if (rv.Result)
                SelectedYsfsbh = rv.Output1;
        }

        void LoadYwbm()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadYwbm",
                new Dictionary<string, string>()
                {
                    {"ywybh",SelectedYwybh}
                });
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListYwbm = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Text = p.Field<string>(1),
                    Value = p.Field<string>(0)
                }).ToList();
            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListYwbm", ListYwbm);
            if (rv.Result)
                SelectedYwbmbh = rv.Output1;
        }

        void LoadYwy()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadYwy",
                new Dictionary<string, string>()
                {
                    {"account",AF.Environment.Identity.Account}
                });
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            ListYwy = qr.Output1.AsEnumerable().Select(p =>
                new TextValuePair()
                {
                    Tag = p.Field<string>(2),
                    Value = p.Field<string>(0),
                    Text = p.Field<string>(1)
                }).ToList();
            //if current user in the list, select current user as default.
            var currentUser = ListYwy.FirstOrDefault(p => p.Tag == AF.Environment.Identity.EmpID);
            if (currentUser != null)
                SelectedYwybh = currentUser.Value;
        }

        void LoadZdch()
        {
            ListZdch = new List<TextValuePair>()
            {
                new TextValuePair("是","Y"),
                new TextValuePair("否","N")
            };
            var rv = AF.DefaultValue.GetDefaultValue(Path, "ListZdch", ListZdch);
            if (rv.Result)
                SelectedZdchbh = rv.Output1;
        }

        void ReportError(string msg)
        {
            App.Alert(msg);
        }

        #endregion

    }
}
