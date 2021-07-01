using DataLayer;
using DriverDriverWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriverDriverWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyTracker()
        {
            List<CourseModel> courseList = new List<Models.CourseModel>();
            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                var courses = db.tblCourses.ToList();
                foreach (var course in courses)
                {
                    CourseModel model = new CourseModel();

                    model.ID = course.CourseID;
                    model.CourseName = course.CourseName;
                    model.Location = course.Location;
                    model.Price = course.Price;
                    model.TimeSpent = course.TimeSpent;
                    model.BallsLost = course.BallsLost;
                    model.Score = course.Score;

                    courseList.Add(model);
                }
            }
            return View(courseList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}