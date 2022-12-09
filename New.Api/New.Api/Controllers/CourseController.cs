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
    public class CourseController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult GetAllCourse()
        {
            string query = @"select * from course";
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
    }
}
   