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
        StudentContext GroupDb = new StudentContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Student()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Student(Student student)
        {
            

            return View();
        }
        [HttpGet]
        public ActionResult Group()
        {
            IEnumerable<Group> groups = GroupDb.Groups;
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
            return View();
        }
        [HttpPost]
        public ActionResult Mark(Mark mark)
        {
            return View();
        }

     
    }
}