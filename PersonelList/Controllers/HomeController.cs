using PersonelList.Models;
using PersonelList.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelList.Controllers
{
    
    public class HomeController : Controller
    {

        DataAccessLayer _dataAccessLayer = new DataAccessLayer();

        public ActionResult AllUserList()
        {
            
            
            var userDTOList = _dataAccessLayer.GetAllUsers();
            return View(userDTOList);
        }

        public ActionResult UserDetail(int id)
        {

            

            var userDTOList = _dataAccessLayer.GetUserDetail(id);
            return View(userDTOList);
        }

        
    }
    public partial class DataAccessLayer
    {
        public List<UserDTO> GetAllUsers()
        {
            UserData userData = new UserData();
            var users= userData.GetAllUsers();
            List<UserDTO> usersDTOList = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO userDTO = new UserDTO()
                {
                    Id=user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDay = user.BirthDay.ToString("dd-MMM-yyyy"),
                    IsManager = user.IsManager,
                    Phone = user.Phone,
                };
                usersDTOList.Add(userDTO);
            }
            return usersDTOList;
        }
        public UserDTO GetUserDetail(int id)
        {
            UserData userData = new UserData();
            var user = userData.GetUsersDetailById(id);


            UserDTO userDTO = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDay = user.BirthDay.ToString("dd-MMM-yyyy"),
                IsManager = user.IsManager,
                Phone = user.Phone,
                Department = user.DepartmanName,
                Id = user.Id,
                ImageListUrl=user.ImageList
                };
               
            
            return userDTO;
        }
    }
    
}