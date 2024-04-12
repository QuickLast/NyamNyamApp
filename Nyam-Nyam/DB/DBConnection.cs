using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.DB
{
    internal class DBConnection
    {
        public static NyamNyam_OsipovEntities nyamNyam = new NyamNyam_OsipovEntities();

        public static Dish selectedDish;
        public static Ingredient selectedIngredient;
    }
}
