using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Medicine_Shopping.Models
{
    public class product
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Price")]
        public float price { get; set; }
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Display(Name = "Category Name")]
        public int category_id { get; set; }
        public int supplier_id { get; set; }
        [Display(Name = "Description")]
        public string descrition { get; set; }

        [Display(Name = "Image")]
        public string image { get; set; }
        [ForeignKey(nameof(category_id))]
        public virtual category category { get; set; }
        [ForeignKey(nameof(supplier_id))]
        public virtual supplier Supplier { get; set; }
    }
}