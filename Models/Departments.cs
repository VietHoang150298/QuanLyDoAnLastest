using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Departments")]
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdate { get; set; }
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculties Faculties { get; set; }

    }
}