using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("SubjectStudents")]
    public class SubjectStudents
    {
        [Key]
        public string SubStuCode { get; set; }
        public string SubStuName { get; set; }

        public bool? IsAcceptName { get; set; }
        public bool? IsFinish { get; set; }

        public double Grade { get; set; }

        public bool? IsFinal { get; set; }

    }
}