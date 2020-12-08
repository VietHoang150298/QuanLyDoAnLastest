using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{   [Table("Teachers")]
    public class Teachers
    {
        [Key]
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public int? GuideStudent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public int SpecializationId { get; set; }
        [ForeignKey("SpecializationId")]
        public virtual Specializations Specializations { get; set; }
    }
}