using System.ComponentModel.DataAnnotations;

namespace New.Api.Models
{
    public class College
    {
        [Key]
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
    }
}
