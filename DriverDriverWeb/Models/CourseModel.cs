using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriverDriverWeb.Models
{
    public class CourseModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Course Name")]
        [StringLength(50, ErrorMessage ="Course Name input cannot be longer than 50 characters.")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Location")]
        [StringLength(50, ErrorMessage = "Location input cannot be longer than 50 characters.")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        [Required]
        [Display(Name = "Time Spent")]
        public string TimeSpent { get; set; }
        [Required]
        [Display(Name = "Balls Lost")]
        public int? BallsLost { get; set; }
        [Required]
        [Display(Name = "Score")]
        [Range(20, 120, ErrorMessage = "Please enter a score between 20 and 120.")]
        public int? Score { get; set; }
    }
}