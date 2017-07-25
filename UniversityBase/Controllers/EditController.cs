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
        StudentContext UniversityDb = new StudentContext();
        // GET: Edit
        [HttpGet]
        public ActionResult AddNewGroup()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddNewGroup(Group group)
        {
            IEnumerable<Group> groups = UniversityDb.Groups;
            foreach (var b in groups)
            {
                if (b.NameOfGroup == group.NameOfGroup)
                {
                    return Json("This name of group is already exist!");
                }
            }
            Group OurNewGroup = new Group
            {
                NameOfGroup = group.NameOfGroup,
                CountOfUsers = 0
                
            };
            UniversityDb.Groups.Add(OurNewGroup);
            UniversityDb.SaveChanges();

            return Json("The group was successfully added!");
        }
        [HttpGet]
        public ActionResult AddNewStudent()
        {
            SelectList groups = new SelectList(UniversityDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;

            return View();
        }
        [HttpPost]
        public JsonResult AddNewStudent(Student student)
        {



            UniversityDb.Students.Add(student);
            UniversityDb.SaveChanges();

            SelectList groups = new SelectList(UniversityDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;


            return Json("Student was successfully added  ");
        }
        [HttpGet]
        public ActionResult AddNewMarkStudent()
        {
            SelectList marks = new SelectList(UniversityDb.Students, "Id", "Name");
            ViewBag.marks = marks;

            return View();
        }
        [HttpPost]
        public JsonResult AddNewMarkStudent(Mark mark)
        {
            IEnumerable<Mark> DbMark = UniversityDb.Marks;
            foreach(var b in DbMark)
            {
                if(b.IdStudent == mark.IdStudent)
                {
                    return Json("There is already exist a similar Student with marks"); 
                }
            }

            UniversityDb.Marks.Add(mark);
            UniversityDb.SaveChanges();


             SelectList marks = new SelectList(UniversityDb.Students, "Id", "Name");
            ViewBag.marks = marks;

            return Json("Marks for student successfully added!");
        }
    }
}