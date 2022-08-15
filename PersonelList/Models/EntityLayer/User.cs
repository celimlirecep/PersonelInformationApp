using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelList.Models.EntityLayer
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmanName { get; set; }
        public List<string> ImageList { get; set; }
    }
}