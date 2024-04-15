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
        public string ImageConverter
        {
            get
            {
                var destinationFormat = string.Empty;
                var allIngredientsRecipeSteps = this.CookingStage.SelectMany(i => i.IngredientOfStage);
                if (allIngredientsRecipeSteps.Any())
                {
                    foreach (var ingredientStep in allIngredientsRecipeSteps)
                    {
                        if (allIngredientsRecipeSteps.Where(i => i.IngredientId == ingredientStep.IngredientId).Sum(i => i.Quantity) >
                            ingredientStep.Ingredient.AvailableCount)
                        {
                            destinationFormat = "Gray32Float";
                            Available = 0;
                            DBConnection.nyamNyam.SaveChanges();
                        }
                    }
                }
                else
                {
                    destinationFormat = "Bgra32";
                    Available = 1;
                    DBConnection.nyamNyam.SaveChanges();
                }
                return destinationFormat;
            }
        }
        public double OurCost
        {
            get
            {
                var v = this.CookingStage.SelectMany(s => s.IngredientOfStage).ToList();
                double result = 0;
                foreach (var i in v)
                {
                    result += i.Ingredient.CostInCents/100 * i.Quantity;
                }
                return result;

            }
        }
    }
}
