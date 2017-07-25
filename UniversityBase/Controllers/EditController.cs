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
        // GET, POST For Add new Model
        [HttpGet]
        public ActionResult AddNewGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewGroup(Group group)
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
            if(ModelState.IsValid)
            {
                UniversityDb.Groups.Add(OurNewGroup);
                UniversityDb.SaveChanges();
                return Json("The group was successfully added!");
            }
            return View(group);
        }
        [HttpGet]
        public ActionResult AddNewStudent()
        {
            SelectList groups = new SelectList(UniversityDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewStudent(Student student)
        {

            if(ModelState.IsValid)
            {
                UniversityDb.Students.Add(student);
                UniversityDb.SaveChanges();
                return Json("Student was successfully added  ");
            }



            SelectList groups = new SelectList(UniversityDb.Groups, "Id", "NameOfGroup");
            ViewBag.Groups = groups;

            return View(student);
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
        //GET, POST for Delete Model
        [HttpPost]
        public ActionResult DeleteGroup(int Id)
        {
            var FindId = UniversityDb.Groups.Find(Id);
            UniversityDb.Groups.Remove(FindId);
            UniversityDb.SaveChanges();


            return RedirectToAction("Group", "Home");
        }
        [HttpPost]
        public ActionResult DeleteMark(int Id)
        {
            var FindId = UniversityDb.Marks.Find(Id);
            UniversityDb.Marks.Remove(FindId);
            UniversityDb.SaveChanges();


            return RedirectToAction("Mark", "Home");
        }
        [HttpPost]
        public ActionResult DeleteStudent(int Id)
        {
            var FindId = UniversityDb.Students.Find(Id);
            UniversityDb.Students.Remove(FindId);
            UniversityDb.SaveChanges();


            return RedirectToAction("Student", "Home");
        }
    }
}