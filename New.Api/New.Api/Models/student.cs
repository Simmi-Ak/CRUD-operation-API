using System.ComponentModel.DataAnnotations;

namespace New.Api.Models
{
    public class student
    {
        [Key]
        public int Roll_Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string College { get; set; }
        public string Course { get; set; }
        public string Joining_Date { get; set; }
    }
}

