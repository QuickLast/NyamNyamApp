using Nyam_Nyam.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Nyam_Nyam.Converters
{
    public class DishColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dish dish = value as Dish;
            int isAvailable = (int)dish.Available;
            object result = System.Convert.ToBoolean(isAvailable) ? PixelFormats.Pbgra32 : PixelFormats.Gray8;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
