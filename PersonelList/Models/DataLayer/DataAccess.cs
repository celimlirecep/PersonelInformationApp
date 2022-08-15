using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelList.Models.DataLayer
{
    public  class DataAccess
    {
        private static DataAccessLayer dal;

        public static DataAccessLayer DAL
        {
            get
            {
                if (dal == null)
                    dal = new DataAccessLayer();
                return dal;
            }
        }
      
    }
}