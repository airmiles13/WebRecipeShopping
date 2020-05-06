using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRecipeShopping.Models
{
    public class IngredientsViewModel
    {
        public Ingredient ingredient { get; set; }
        public List<Ingredient> ingredients {get; set;}
    }
}