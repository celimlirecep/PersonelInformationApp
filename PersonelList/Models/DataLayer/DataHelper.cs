using PersonelList.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonelList.Models.DataLayer
{
    public  class DataHelper:DataAccess
    {
        /// <summary>
        /// Returns datatable based on given procedure name
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public DataTable GetMyDataByProcedureName(string procedureName)
        {
            try
            {
                DAL.ConnectionOpen();
                SqlCommand cmd = new SqlCommand(procedureName, DAL.ConnectionDB);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            finally
            {

                DAL.ConnectionClose();
            }
        }
        public DataTable GetMyDataByProcedureNameWithId(string procedureName, int id)
        {
            DataTable dt = new DataTable();
            try
            {
                DAL.ConnectionOpen();
                SqlCommand cmd = new SqlCommand(procedureName, DAL.ConnectionDB);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                SqlDataReader reader = cmd.ExecuteReader();
                
                dt.Load(reader);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            return dt;
        }
        public void InsertUser(string userProcedureName,string imageProcedureName,Register register,List<ImageDTO> imagesList)
        {
           
            try
            {
                DAL.ConnectionOpen();
                SqlCommand cmdUser = new SqlCommand(userProcedureName, DAL.ConnectionDB);
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.AddWithValue("@FirstName", register.FirstName);
                cmdUser.Parameters.AddWithValue("@LastName", register.LastName);
                cmdUser.Parameters.AddWithValue("@Phone", register.Phone);
                cmdUser.Parameters.AddWithValue("@BirthDay", register.BirthDay);
                cmdUser.Parameters.AddWithValue("@IsManger", register.IsManager);
                cmdUser.Parameters.AddWithValue("@DepartMentId", register.DepartmentId);
                cmdUser.ExecuteNonQuery();
                foreach (var image in imagesList)
                {
                    SqlCommand cmdImage = new SqlCommand(imageProcedureName, DAL.ConnectionDB);
                    cmdImage.CommandType = CommandType.StoredProcedure;
                    cmdImage.Parameters.AddWithValue("@UserId", image.UserId);
                    cmdImage.Parameters.AddWithValue("@ImagePath", image.ImagePath);
                    cmdImage.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAL.ConnectionClose();
            }
        }

      


    }
   
}