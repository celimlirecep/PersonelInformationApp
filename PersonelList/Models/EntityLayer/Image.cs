using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelList.Models.EntityLayer
{
    public class Image
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
    }
}