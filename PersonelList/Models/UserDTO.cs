using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelList.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<string> ImageListUrl { get; set; }
        public string BirthDay { get; set; }
        public bool IsManager { get; set; }
        public string Department { get; set; }

    }
}