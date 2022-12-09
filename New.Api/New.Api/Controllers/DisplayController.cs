using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace New.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayController : ControllerBase

    {
        private readonly IConfiguration _configuration;

        public DisplayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

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
    }
}
