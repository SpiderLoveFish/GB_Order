using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GBERP.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            WorkMode = WorkModeEnum.View;
            Path = this.GetType().FullName;
            PageID = AF.Environment.GetNewPageID();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkModeEnum WorkMode { get; set; }

        /// <summary>
        /// 唯一地标识一个页面
        /// </summary>
        public int PageID { get; set; }

        /// <summary>
        /// 等于当前类型的FullName。用于从外部引用当前类。
        /// 以及用于搜索当前类的配置文件等。
        /// </summary>
        public string Path { get; private set; }

        public void TryExecuteCommand(string commandName)
        {
            var pi = this.GetType().GetProperty(commandName, typeof(ICommand));
            if (pi == null)
                return;
            var cmd = (ICommand)pi.GetValue(this);
            cmd.Execute(null);
        }

        protected void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public enum WorkModeEnum
        {
            Insert,
            Edit,
            View,
            Approve
        }
    }
}
