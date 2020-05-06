using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebRecipeShopping.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Ingredient")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters long")]
        [Required(ErrorMessage="Must enter an ingredient.")]
        public string ingredient { get; set; }
    }
}