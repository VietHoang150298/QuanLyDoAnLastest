using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        [DataType(DataType.DateTime)]
        
        public DateTime StartDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }

    }
}