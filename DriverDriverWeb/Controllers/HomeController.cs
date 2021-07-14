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
                    ViewBag.lastCoursePlayed = course.CourseName.ToString();
                }
            }
            return View(courseList);
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

        public ActionResult CreateCourseEntry()
        {
            CourseModel model = new CourseModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCourseEntry(CourseModel model)
        {
            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                tblCours course = new tblCours();
                course.CourseName = model.CourseName;
                course.Location = model.Location;
                course.Price = model.Price;
                course.TimeSpent = model.TimeSpent;
                course.BallsLost = model.BallsLost;
                course.Score = model.Score;

                db.tblCourses.Add(course);

                db.SaveChanges();

                return RedirectToAction("MyTracker");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CourseModel model = new CourseModel();
            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                var course = db.tblCourses.FirstOrDefault(x => x.CourseID == id);
                if (course != null)
                {
                    model.ID = course.CourseID;
                    model.CourseName = course.CourseName;
                    model.Location = course.Location;
                    model.Price = course.Price;
                    model.TimeSpent = course.TimeSpent;
                    model.BallsLost = course.BallsLost;
                    model.Score = course.Score;

                }
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CourseModel model)
        {
            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                var course = db.tblCourses.FirstOrDefault(x => x.CourseID == model.ID);
                course.CourseName = model.CourseName;
                course.Location = model.Location;
                course.Price = model.Price;
                course.TimeSpent = model.TimeSpent;
                course.BallsLost = model.BallsLost;
                course.Score = model.Score;

                db.Entry(course).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("MyTracker");
            }
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

        public ActionResult Details(int id)
        {
            CourseModel model = new CourseModel();

            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                var course = db.tblCourses.FirstOrDefault(x => x.CourseID == id);
                if (course != null)
                {
                    model.ID = course.CourseID;
                    model.CourseName = course.CourseName;
                    model.Location = course.Location;
                    model.Price = course.Price;
                    model.TimeSpent = course.TimeSpent;
                    model.BallsLost = course.BallsLost;
                    model.Score = course.Score;

                }
            }
            return View(model);
        }

        public ActionResult Delete(int ID)
        {
            CourseModel model = new CourseModel();
            using (GolfRecordsDBEntities db = new GolfRecordsDBEntities())
            {
                var course = db.tblCourses.FirstOrDefault(x => x.CourseID == ID);
                db.tblCourses.Remove(course);
                db.SaveChanges();

                return RedirectToAction("MyTracker");
            }
        }

    }
}