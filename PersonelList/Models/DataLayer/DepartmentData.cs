using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonelList.Models.DataLayer
{
    public class DepartmentData:DataHelper
    {
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                DataTable dt = GetMyDataByProcedureName("dbo.Get_All_Departments");
                foreach (DataRow row in dt.Rows)
                {
                    Department department = new Department()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        

                    };
                    departments.Add(department);
                }
            }
            catch (Exception ex)
            {
                //log
                Console.WriteLine(ex.Message);
            }
            return departments;
        }
    }
}