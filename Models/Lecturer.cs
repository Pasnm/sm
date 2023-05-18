using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LId { get; set; }
        public int CId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public Class Class { get; set; }

    }
}