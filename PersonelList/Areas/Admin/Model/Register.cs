using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelList.Areas.Admin.Model
{
    public class Register
    {
        [Required(ErrorMessage ="Is Required")]
        [StringLength(15,ErrorMessage ="Please enter 5 to 50 character",MinimumLength =5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [StringLength(15, ErrorMessage = "Please enter 5 to 50 character", MinimumLength = 5)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [StringLength(12, ErrorMessage = "Please enter 5 to 50 character")]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyyy}",ApplyFormatInEditMode =true)]
        public DateTime BirthDay { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
       

    }
}