using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace New.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CollegeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetAllCollege()
        {
            string query = @"select * from College";
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
