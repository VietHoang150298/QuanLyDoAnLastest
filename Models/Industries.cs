using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Industries")]
    public class Industries
    {
        [Key]
        public int IndustryId { get; set; }
        [StringLength(50)]
        public string IndustryName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Departments Departments { get; set; }
    }
}