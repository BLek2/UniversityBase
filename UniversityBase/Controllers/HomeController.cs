using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using UniversityBase.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Dynamic;
using Newtonsoft.Json;

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

        
        public ActionResult Student()
        {
         
            

            return View();
        }
        [HttpGet]
        public JsonResult JsonStudent()
        {
            IEnumerable<Student> students = UniversityDb.Students;
            IEnumerable<Group> groups = UniversityDb.Groups;

            var Students = students.Join(groups,
                p => p.GroupId,
                c => c.Id,
                (p, c) => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    AgeOfBirth = p.AgeOfBirth,
                    Course = p.Course,
                    Age = p.Age,
                    Group = c.NameOfGroup

                });

            var studentResult = JsonConvert.SerializeObject(Students);



            return Json(studentResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult StudentResult(string FindName, string FindSurname, int? Age, int? Course)
        {
            if (Age == null)
            {
                Age = 0;
            }
            if (Course == null)
            {
                Course = 0;
            }

            SqlParameter parametr1 = new SqlParameter("@Name", FindName);
            SqlParameter parametr2 = new SqlParameter("@Surname", FindSurname);
            SqlParameter parametr3 = new SqlParameter("@Age", Age);
            SqlParameter parametr4 = new SqlParameter("@Course", Course);

            var StudentsByName = UniversityDb.Students.SqlQuery("SELECT * FROM dbo.Students " +
                "WHERE Name LIKE @Name OR Surname LIKE @Surname OR Age=@Age OR Course=@Course  ", parametr1, parametr2, parametr3, parametr4);


            ViewBag.StudentsByName = StudentsByName;

            return PartialView();
        }

        public ActionResult AdvanceSearch()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Group()
        {
            IEnumerable<Group> groups = UniversityDb.Groups;
            ViewBag.groups = groups;
            return View();
        }

        [HttpPost]
        public ActionResult GroupResult(string NameOfGroup, int? CountOfUsers)
        {
            if (CountOfUsers == null)
            {
                CountOfUsers = 0;
            }

            SqlParameter parametr1 = new SqlParameter("@NameOfGroup", NameOfGroup);
            SqlParameter parametr2 = new SqlParameter("@CountOfUsers", CountOfUsers);

            var GroupSearched = UniversityDb.Groups.SqlQuery("SELECT * FROM dbo.Groups WHERE NameOfGroup LIKE @NameOfGroup OR CountOfUsers=@CountOfUsers", parametr1, parametr2);

            ViewBag.GroupSearched = GroupSearched;
            return PartialView();
        }
        [HttpGet]
        public ActionResult Mark()
        {
            return View();
        }
        [HttpGet]
        public JsonResult JsonMark()
        {
            IEnumerable<Mark> marks = UniversityDb.Marks;
            IEnumerable<Student> students = UniversityDb.Students;

            marks.Where(p => p.Id > 0);

            var Marks = marks.Join(students,
                p => p.IdStudent,
                c => c.Id,
                (p, c) => new
                {
                    Id = p.Id,
                    Math = p.Math,
                    History = p.History,
                    Psychology = p.Psychology,
                    Literature = p.Literature,
                    Cooking = p.Cooking,
                    Music = p.Music,
                    Law = p.Law,
                    Programming = p.Programming,
                    WebDesign = p.WebDesign,
                    Student = c.Name + " " + c.Surname + " " +"-- Course: " + c.Course
                });

            var ResultMarks = JsonConvert.SerializeObject(Marks);

            return Json(ResultMarks, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult MarkFromStudent(int? Id)
        {
            var OurStudent = UniversityDb.Students.Find(Id);

            var FindMarkStudent = UniversityDb.Marks.Where(p => p.IdStudent == OurStudent.Id);

            ViewBag.FindMarkStudent = FindMarkStudent;
      
            ViewBag.IdStudent = Id;

            return View();
        }
   


    }
}