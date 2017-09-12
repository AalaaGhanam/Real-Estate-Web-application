using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealState2.Models
{
    public class User
    {
        public long ID { set; get; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Please Enter VALID Name")]
        public string FirstName { set; get; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter VALID Name")]
        public string LastName { set; get; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please Enter VALID Name")]
        public string UserName { set; get; }
        [MaxLength(50), MinLength(2)]
        [Required(ErrorMessage ="Please Enter your password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public long Mobile { set; get; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage ="Please Enter Valid Email Address")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Please Enter VALID Job descrption")]
        [Display(Name = "Job Description")]
        public string JobDescription { set; get; }
        [Display(Name = "Job Role")]
        public string JobRole { set; get; }
        public byte[] Photo { set; get; }
    }
}