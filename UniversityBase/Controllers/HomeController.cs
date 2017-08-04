using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
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
        public ActionResult Student(Student student,string FindNames)
        {
            IEnumerable<Student> students = UniversityDb.Students;
            ViewBag.students = students;

           
            return View();
        }
        [HttpPost]
        public ActionResult StudentResult(string FindName, string FindSurname, int? Age, int? Course)
        {
            if(Age == null){            
                    Age = 0;
            }
            if(Course == null){                
                    Course = 0;
            }

            System.Data.SqlClient.SqlParameter parametr1 = new System.Data.SqlClient.SqlParameter("@Name", FindName);
            System.Data.SqlClient.SqlParameter parametr2 = new System.Data.SqlClient.SqlParameter("@Surname", FindSurname);
            System.Data.SqlClient.SqlParameter parametr3 = new System.Data.SqlClient.SqlParameter("@Age", Age);
            System.Data.SqlClient.SqlParameter parametr4 = new System.Data.SqlClient.SqlParameter("@Course", Course);
 
            var StudentsByName = UniversityDb.Students.SqlQuery("SELECT * FROM dbo.Students " +
                "WHERE Name LIKE @Name OR Surname LIKE @Surname OR Age=@Age OR Course=@Course  ", parametr1, parametr2,parametr3,parametr4);




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