using System.ComponentModel.DataAnnotations;

namespace New.Api.Models
{
    public class course
    {
        [Key]
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public string Course { get; set; }

    }
}
