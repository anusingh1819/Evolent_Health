using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactOperations.Models
{
	public class ContactModel
	{
        public int Id { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is required")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string Last_Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email  is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone no is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid")]
        public string Phone_Number { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        [Range(0,1, ErrorMessage ="Please enter boolean values")]
        public Nullable<int> Status { get; set; }
    }
}