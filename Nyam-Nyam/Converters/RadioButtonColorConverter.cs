using Nyam_Nyam.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.Converters
{
    public class RadioButtonColorConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IngredientOfStage stage = (IngredientOfStage)value;
            return stage.ColorRadioButtom ? "Green" : "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
