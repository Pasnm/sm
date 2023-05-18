using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }
        public string ClassName { get; set; }
       

        public ICollection<Students> Students { get; set; }
        public ICollection<Lecturer> Lecturer { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }

    }
}