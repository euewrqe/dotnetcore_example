using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }

        // [Required, StringLength(1000), Display(Name ="Product Description"), DataType(DataType.MultilineText)]
        [Display(Name ="Product Description")]
        public string Description { get; set; }

        // category -> product
        public virtual ICollection<Product> Products { get; set; }
    }
}