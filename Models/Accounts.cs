using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [StringLength(20)]
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }
        public string StudentCode { get; set; }
        [ForeignKey("StudentCode")]
        public virtual Students Students { get; set; }
        public string TeacherCode { get; set; }
        [ForeignKey("TeacherCode")]
        public virtual Teachers Teachers { get; set; }
    }
}