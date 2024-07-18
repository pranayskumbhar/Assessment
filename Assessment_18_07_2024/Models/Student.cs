using System.ComponentModel.DataAnnotations;

namespace Assessment_18_07_2024.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? StudentUsername { get; set; }
        public string? StudentPassword { get; set; }
        public DateTime create_date { get; set; }
    }
}
