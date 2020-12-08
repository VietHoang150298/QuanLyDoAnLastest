using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAnLastest.Models.ViewModel
{
    public class EnrollmentViewModel
    {
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string Position { get; set; }
        public string TeacherPhoneNumber { get; set; }
        public int? GuideStudent { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
    }
}