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
                return RedirectToAction("Group", "Home");
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
           
                

            if (ModelState.IsValid)
            {
                UniversityDb.Students.Add(student);
                UniversityDb.SaveChanges();

                var groupSelected = UniversityDb.Groups.Find(student.GroupId);
                groupSelected.CountOfUsers++;
                UniversityDb.Entry(groupSelected).State = System.Data.Entity.EntityState.Modified;
                UniversityDb.SaveChanges();

                return RedirectToAction("Student", "Home");
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
        public ActionResult AddNewMarkStudent(Mark mark)
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

            return RedirectToAction("Mark", "Home");
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
        //GET, POST for Edit Model

        //Mark -- EDIT
        [HttpGet]
        public ActionResult ChangeOurMark(Mark SendModel)
        {


            return View(SendModel);
        }
        [HttpPost]
        public ActionResult ChangeOurMark(Mark mark, int Id)
        {
            UniversityDb.Entry(mark).State = System.Data.Entity.EntityState.Modified;
            UniversityDb.SaveChanges();


            return RedirectToAction("Mark", "Home");
        }

        [HttpPost]
        public ActionResult EditMark(int Id)
        {
            var SendModel = UniversityDb.Marks.Find(Id);


            return View("ChangeOurMark", SendModel);
        }


        //Group -- EDIT
        [HttpPost]
        public ActionResult EditGroup(int Id)
        {
            var SendModel = UniversityDb.Groups.Find(Id);


            return View("ChangeOurGroup", SendModel);
        }
        [HttpGet]
        public ActionResult ChangeOurGroup(Group SendModel)
        {


            return View(SendModel);
        }
        [HttpPost]
        public ActionResult ChangeOurGroup(Group group, int Id)
        {
            UniversityDb.Entry(group).State = System.Data.Entity.EntityState.Modified;
            UniversityDb.SaveChanges();


            return RedirectToAction("Group", "Home");
        }
        //Student -- EDIT:

    
        [HttpPost]
        public ActionResult EditStudent(int Id)
        {
            var SendModel = UniversityDb.Students.Find(Id);


            return View("ChangeOurStudent", SendModel);
        }
        [HttpGet]
        public ActionResult ChangeOurStudent(Student SendModel)
        {
           

            return View(SendModel);
        }
        [HttpPost]
        public ActionResult ChangeOurStudent(Student student, int Id)
        {
            UniversityDb.Entry(student).State = System.Data.Entity.EntityState.Modified;
            UniversityDb.SaveChanges();


            return RedirectToAction("Student","Home");
        }
    }
}