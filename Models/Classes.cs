using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Classes")]
    public class Classes
    {
        [Key]
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public int SpecializationId { get; set; }
        [ForeignKey("SpecializationId")]
        public virtual Specializations Specializations { get; set; }
    }
}