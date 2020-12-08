using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{   
    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public string StudentCode { get; set; }
        [ForeignKey("StudentCode")]
        public virtual Students Students { get; set; }
        public string TeacherCode { get; set; }
        [ForeignKey("TeacherCode")]
        public virtual Teachers Teachers { get; set; }
    }
}