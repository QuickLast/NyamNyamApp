//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nyam_Nyam.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientOfStage
    {
        public int CookingStageId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
    
        public virtual CookingStage CookingStage { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
