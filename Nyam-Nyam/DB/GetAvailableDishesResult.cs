using System;

namespace Nyam_Nyam.DB
{
    internal class GetAvailableDishesResult
    {
        public int dish_id { get; set; }
        public string dish_name { get; set; }
        public Nullable<int> ingredient_count { get; set; }
    }
}
