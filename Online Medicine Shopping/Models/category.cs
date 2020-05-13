using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Medicine_Shopping.Models
{
    public class category
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Category Name")]
        public string name { get; set; }
    }
}