using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.DB
{
    public partial class IngredientOfStage
    {
        private bool _color;
        public bool ColorRadioButtom
        {
            get
            {
                return _color;
                //if (Quantity * CookingStage.Dish.BaseServingsQuantity <= Ingredient.AvailableCount)
                //    return true;
                //else
                //    return false;
            }
            set
            {
                _color = value;
            }
        }
    }
}
