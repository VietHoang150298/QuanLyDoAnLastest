using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models
{
    [Table("Students")]
    public class Students
    {
        [Key]
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public string ClassCode { get; set; }
        [ForeignKey("ClassCode")]
        public virtual Classes Classes { get; set; }
    }
}