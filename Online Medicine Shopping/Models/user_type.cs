using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Medicine_Shopping.Models
{
    public class user_type
    {
        [Key]
        public int type_id { get; set; }
        public string type_name { get; set; }
    }
}