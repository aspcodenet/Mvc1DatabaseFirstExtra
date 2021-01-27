using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc1DatabaseFirstExtra.ViewModels
{
    // ÖKAD FLEXIBILITET !!!

    //1. Behövs för att kunna rita ut sidan
        //selectlistitems
        // "databärare" mellan controller och vy

    //2. De fält som användaren ska kunna ändra på och "skicka" in till oss så vi kan uppdatera databas
        // visa startvärdet 
        // generera validering
        // "databärare" mellan användare och "oss"

    public class ProductEditViewModel
    {
        [MaxLength(40)] //-> utföra valdiering   ModelState.IsValid
                        //   används för att generera data-val-# maxlength-attr i html  asp-for asp-validation-for   
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }

        public List<int> LatestOrderNumbers { get; set; }

    }
}