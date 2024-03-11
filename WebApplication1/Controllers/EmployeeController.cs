using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select EmployeeId,EmployeeName,Department,convert(varchar(10),DateOfJoining) as DateOfJoining, PhotoFileName from Employee";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Employee emp)
        {
            try
            {
                string query = @"insert into Employee values(
                '"+emp.EmployeeName+ @"',
                '"+emp.Department+ @"',
                '"+emp.DateOfJoining+@"',
                '"+emp.PhotoFileName+@"'
          
)"
;
                //paste data
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added successfully";
            }
            catch (Exception)
            {

                return "Failed to Add";
            }
        }
        public string Put(Employee emp)
        {
            try
            {
                string query =
                    @"update Employee 
                    set EmployeeName = ('" + emp.EmployeeName + @"'),
                        Department = ('" + emp.Department + @"'),
                        DateOfJoining = ('" + emp.DateOfJoining + @"'),
                        PhotoFileName = ('" + emp.PhotoFileName + @"')
                    where EmployeeId =" + emp.EmployeeId + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "updated successfully";
            }
            catch (Exception)
            {

                return "Failed to update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from Employee where EmployeeID=" + id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "deleted successfully";
            }
            catch (Exception)
            {

                return "Failed to delete";
            }
        }
        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet] //attribute to know this is a get method
        //custom method
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"select DepartmentName from Department ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK,table);
        }

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var pytsicalPath = HttpContext.Current.Server.MapPath("~/Photos/"+filename);
                postedFile.SaveAs(pytsicalPath);
                return filename;

            }
            catch (Exception)
            {
                return "anonymous";
            }
        }
    }
}
