using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get() {
            string query = @"select DepartmentId,DepartmentName from Department";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString)) 
                using (var cmd = new SqlCommand(query,con))
                using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK,table);
         }
        public string Post(Department dep)
        {
            try
            {
                string query = @"insert into Department values ('"+dep.DepartmentName+@"')";
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
        public string Put(Department dep)
        {
            try
            {
                string query = 
                    @"update Department 
                    set DepartmentName = ('" + dep.DepartmentName + @"')
                    where DepartmentId ="+dep.DepartmentId+@"";
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
                string query = @"delete from Department where DepartmentId=" + id + @"";

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
        [Route("api/Department/GetAllDepartmentNames")]
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
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
