using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverDriverWeb.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public decimal? Price { get; set; }
        public string TimeSpent { get; set; }
        public int? BallsLost { get; set; }
        public int? Score { get; set; }
    }
}