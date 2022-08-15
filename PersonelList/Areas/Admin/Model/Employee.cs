using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelList.Areas.Admin.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string ImageList { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsManager { get; set; }

    }
}