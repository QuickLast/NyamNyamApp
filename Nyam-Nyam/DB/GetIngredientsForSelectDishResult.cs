using System;

namespace Nyam_Nyam.DB
{
    internal class GetIngredientsForSelectDishResult
    {
        public string Name { get; set; }
        public double AvailableCount { get; set; }
        public int CostInCents { get; set; }
    }
}
