using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Medicine_Shopping.Models
{
    public class users
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Required User Name filled with minimum Length 5 Characters"), MinLength(5), MaxLength(20)]
        [Display(Name = "User Name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Required Password  filled with minimum Length 10 Characters"), MinLength(10), MaxLength(25), DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }


        [ForeignKey(nameof(type_id))]
        [Display(Name = "Role Name")]
        public virtual user_type user_type { get; set; }
        public int type_id { get; set; }

        [Required(ErrorMessage = "Required Full Name filled with minimum Length 5 Characters"), MinLength(5), MaxLength(20)]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }
        [DataType(DataType.EmailAddress)]

        [Required(ErrorMessage = "Required Email filled")]
        [Display(Name = "Email")]
        public string email { get; set; }

    }
}