using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.DB
{
    public partial class Dish
    {
        public double OurCost
        {
            get
            {
                var v = this.CookingStage.SelectMany(s => s.IngredientOfStage).ToList();
                double result = 0;
                foreach (var i in v)
                {
                    result += i.Ingredient.CostInCents * i.Quantity;
                }
                return result;

            }
        }
    }
}
