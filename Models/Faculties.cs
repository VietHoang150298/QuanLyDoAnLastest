using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Faculties")]
    public class Faculties
    {
        [Key]
        public int FacultyId { get; set; }
        [StringLength(50)]
        public string FacultyName { get; set; }
        public string Email { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}