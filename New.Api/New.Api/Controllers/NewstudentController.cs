using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using New.Api.Models;
using System.Configuration;

namespace New.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewstudentController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public NewstudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult GetAllnewstudent()
        {
            string query = @"select Roll_Number,FirstName,LastName,college_name,course_name,Joining_Date from newstudents 
                                    join College on College.collegeID=newstudents.College 
                            join course on course.courseID=newstudents.Course;";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
            SqlDataReader myreader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    myreader = cmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);

        }


        [HttpGet("{Roll_Number}")]

        public JsonResult Display(string Roll_Number)
        {
            string query = @"select * from newstudents where Roll_Number=@Roll_Number";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
            SqlDataReader myreader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Roll_Number", Roll_Number);
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);

        }

        /* [HttpGet]

         public JsonResult Display(string Roll_Number)
         {
             string query = @"select * from newstudents where Roll_Number=@Roll_Number";
             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
             SqlDataReader myreader;
             using (SqlConnection con = new SqlConnection(sqlDataSource))
             {
                 con.Open();
                 using (SqlCommand cmd = new SqlCommand(query, con))
                 {
                     cmd.Parameters.AddWithValue("@Roll_Number", Roll_Number);
                     myreader = cmd.ExecuteReader();
                     table.Load(myreader);
                     myreader.Close();
                     con.Close();
                 }
             }
             return new JsonResult(table);

         }*/

        [HttpPost]

        public JsonResult Addnewstuden(student s)
        {
            string query = @"insert into newstudents values (@Roll_Number,@FirstName,@LastName,@College,@Course,@Joining_Date)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
            SqlDataReader myreader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Roll_Number", s.Roll_Number);
                    cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", s.LastName);
                    cmd.Parameters.AddWithValue("@College", s.College);
                    cmd.Parameters.AddWithValue("@Course", s.Course);
                    cmd.Parameters.AddWithValue("@Joining_Date", s.Joining_Date);

                    myreader = cmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    con.Close();
                }
            }
            return new JsonResult("New records added successfully");

        }
        [HttpPut]
        public JsonResult Upadtestudent(student s)
        {
            string query = @"update newstudents set FirstName=@FirstName,LastName=@LastName,College=@College,Course=@Course,Joining_Date=@Joining_Date
                            where Roll_Number=@Roll_Number";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
            SqlDataReader myreader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Roll_Number", s.Roll_Number);
                    cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", s.LastName);
                    cmd.Parameters.AddWithValue("@College", s.College);
                    cmd.Parameters.AddWithValue("@Course", s.Course);
                    cmd.Parameters.AddWithValue("@Joining_Date", s.Joining_Date);

                    myreader = cmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Updated successfully");

        }

       [HttpDelete]
         public JsonResult Deletestudent(int Roll_Number)
         {
             string query = @" delete from newstudents  where Roll_Number=@Roll_Number";
             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
             SqlDataReader myreader;
             using (SqlConnection con = new SqlConnection(sqlDataSource))
             {
                 con.Open();
                 using (SqlCommand cmd = new SqlCommand(query, con))
                 {
                     cmd.Parameters.AddWithValue("@Roll_Number", Roll_Number);
                     myreader = cmd.ExecuteReader();
                     table.Load(myreader);
                     myreader.Close();
                     con.Close();
                 }
             }
             return new JsonResult("Deleted successfully");

         }
        /*[HttpDelete]
         public string Deletestudent(int Roll_Number)
         {
             try
             {
                 string query = @"delete from newstudents where Roll_Number=" + Roll_Number + @"";
                 DataTable table = new DataTable();
                 string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
                 using (SqlConnection con = new SqlConnection(sqlDataSource))
                     using(var cmd=new SqlCommand(query,con))
                     using (var da=new SqlDataAdapter(cmd))
                 {
                     cmd.CommandType = CommandType.Text;
                     da.Fill(table);
                 }
                 return "Delete successfully";
             }

             catch(Exception)
             {
                 return "failed";
             }
         }*/
        /*[HttpDelete]
        public JsonResult Deletestudent(int Roll_Number)
        {
            string query = @" DELETE 
            FROM newstudents inner join College on  College.collegeID=newstudents.College
            join course on course.courseID=newstudents.Course
                    WHERE Roll_Number=@Roll_Number";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StudentConnection");
            SqlDataReader myreader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Roll_Number", Roll_Number);
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Deleted successfully");

        }*/

    }
}
