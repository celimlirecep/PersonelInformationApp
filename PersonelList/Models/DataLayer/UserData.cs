using PersonelList.Areas.Admin.Model;
using PersonelList.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonelList.Models.DataLayer
{
    public class UserData:DataHelper
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                DataTable dt = GetMyDataByProcedureName("dbo.Get_All_User_HomePage");
                foreach (DataRow row in dt.Rows)
                {
                    User user = new User()
                    {
                        Id= Convert.ToInt32(row["Id"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        Phone = Convert.ToString(row["Phone"]),
                        
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                //log
                Console.WriteLine(ex.Message);
            }
            return users;
        }
        public User GetUsersDetailById(int id)
        {
            User user = null;
            try
            {
              
                DataTable dt = GetMyDataByProcedureNameWithId("dbo.GET_USER_DETAİL_BYID", id);
                foreach (DataRow row in dt.Rows)
                {
                     user = new User()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        Phone = Convert.ToString(row["Phone"]),
                        BirthDay = Convert.ToDateTime(row["BirthDay"]),
                        IsManager = Convert.ToBoolean(row["Ismanager"]),
                        DepartmanName = Convert.ToString(row["Name"]),
                        
                    };
                   
                }
                DataTable dt2 = GetMyDataByProcedureNameWithId("dbo.GET_USER_IMAGES_BYID", id);
                DAL.ConnectionClose();
                List<string> images = new List<string>();
                foreach (DataRow row in dt2.Rows)
                {
                    string image = Convert.ToString(row["ImagePath"]);
                    images.Add(image);
                        
                }
                user.ImageList=images;
            }
            catch (Exception ex)
            {
                //log
                Console.WriteLine(ex.Message);
            }
            return user;
        }
        public void AddUser(Register register,List<ImageDTO> images)
        {
            InsertUser("dbo.ADD_USERS_TABLE", "dbo.ADD_USER_IMAGES", register, images);
            
        }



    }
}