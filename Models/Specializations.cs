using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Specializations")]
    public class Specializations
    {
        [Key]
        public int SpecializationId { get; set; }
        [StringLength(50)]
        public string SpecializationName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public int IndustryId { get; set; }
        [ForeignKey("IndustryId")]
        public virtual Industries Industries { get; set; }
    }
}