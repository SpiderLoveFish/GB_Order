using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBERP.AF
{
    public class DataSelect
    {
        public static void DataSelectSingle(string title)
        {
            GBERP.App.RootWindow.OpenNewPage("GBERP.View.General.DataSelect", title);
        }
    }
}
