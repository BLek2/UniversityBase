using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityBase.Models;

namespace UniversityBase.Controllers
{
    public class HomeController : Controller
    {
        StudentContext UniversityDb = new StudentContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Student()
        {
            IEnumerable<Student> students = UniversityDb.Students;
            ViewBag.students = students;


            return View();
        }
        [HttpPost]
        public ActionResult Student(Student student)
        {
            IEnumerable<Student> students = UniversityDb.Students;
            ViewBag.students = students;
            

            return View();
        }
        [HttpGet]
        public ActionResult Group()
        {
            IEnumerable<Group> groups = UniversityDb.Groups;
            ViewBag.groups = groups;


            return View();
        }
        [HttpPost]
        public ActionResult Group(Group group)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Mark()
        {
            IEnumerable<Mark> marks = UniversityDb.Marks;
            ViewBag.marks = marks;



            return View();
        }
        [HttpPost]
        public ActionResult Mark(Mark mark)
        {
            return View();
        }

     
    }
}