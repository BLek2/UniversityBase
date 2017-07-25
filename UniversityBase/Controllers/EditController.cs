using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityBase.Models;

namespace UniversityBase.Controllers
{
    public class EditController : Controller
    {
        StudentContext GroupDb = new StudentContext();
        // GET: Edit
        [HttpGet]
        public ActionResult AddNewGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewGroup(Group group)
        {
            GroupDb.Groups.Add(group);
            GroupDb.SaveChanges();

            return View();
        }
        [HttpGet]
        public ActionResult AddNewStudent()
        {
            SelectList groups = new SelectList(GroupDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewStudent(Student student)
        {
            GroupDb.Students.Add(student);
            GroupDb.SaveChanges();

            SelectList groups = new SelectList(GroupDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;


            return View();
        }
    }
}