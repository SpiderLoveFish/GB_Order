using GBERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GBERP.ViewModel.General
{
    public class DataSelect : ViewModelBase
    {
        public DataSelect()
        {
            Task.Run(() =>
            {
                LoadDataSource();
            });
        }
        private DataTable _dataSource;
        public DataView DataSource
        {
            get
            {
                if (_dataSource == null)
                    return null;
                return _dataSource.AsDataView();
            }
            set
            {
                NotifyPropertyChanged("DataSource");
            }
        }

        public ICommand ClearSelect
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                    }
                );
            }
        }

        public ICommand SelectAll
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
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

                    }
                );
            }
        }




        private void LoadDataSource()
        {
            var qr = AF.DAL.ServiceWrapper.GetData(AF.DAL.ServiceWrapper.FactoryEnum.GBMM,
                "wcm_Sales_Order_OrderDetail_LoadCjfs");
            if (!qr.Result)
            {
                ReportError(qr.Message);
                return;
            }
            _dataSource = qr.Output1;
            DataSource = null;
        }

        private void ReportError(string msg)
        {
            App.Alert(msg);
        }
    }
}
