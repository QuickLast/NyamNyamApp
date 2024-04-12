using Nyam_Nyam.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.Service
{
    public class CheckAvailableDishes
    {
        public static void Check()
        {
            List<Dish> dishes = DBConnection.nyamNyam.Dish.ToList();
            for (int i = 0; i < dishes.Count; i++)
            {
                dishes[i].Available = 1;
                int id = dishes[i].Id;
                List<CookingStage> cookingStages = DBConnection.nyamNyam.CookingStage.Where(x => x.DishId == id).ToList();
                List<IngredientOfStage> ingredientOfStages = new List<IngredientOfStage>(0);
                for (int j = 0; j < cookingStages.Count; j++)

                {
                    int stageId = cookingStages[j].Id;
                    List<IngredientOfStage> temp = DBConnection.nyamNyam.IngredientOfStage.Where(x => x.CookingStageId == stageId).ToList();
                    for (int k = 0; k < temp.Count; k++)
                    {
                        ingredientOfStages.Add(temp[k]);
                    }
                }
                for (int j = 0; j < ingredientOfStages.Count; j++)
                {
                    if (ingredientOfStages[j].Ingredient.AvailableCount < ingredientOfStages.Where(x => x.IngredientId == ingredientOfStages[j].IngredientId).Sum(x => x.Quantity))
                    {
                        dishes[i].Available = 1;
                    }
                }
            }
            DBConnection.nyamNyam.SaveChanges();
        }
    }
}
