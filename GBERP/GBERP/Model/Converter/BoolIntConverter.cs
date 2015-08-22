using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GBERP.Model.Converter
{
    public class BoolIntConverter : IValueConverter
    {
        public BoolIntConverter()
        {
            //by default, true will be 0, false will be 1. 
            //but these values could be overwritten by xaml page.
            TrueIndex = 0;
            FalseIndex = 1;
        }

        public int TrueIndex { get; set; }
        public int FalseIndex { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? TrueIndex : FalseIndex;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((int)value == TrueIndex);
        }
    }
}
