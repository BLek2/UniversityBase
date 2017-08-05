using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using UniversityBase.Models;
using System.Data.SqlClient;


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
        public ActionResult StudentResult(string FindName, string FindSurname, int? Age, int? Course)
        {
            if(Age == null){            
                    Age = 0;
            }
            if(Course == null){                
                    Course = 0;
            }

            SqlParameter parametr1 = new SqlParameter("@Name", FindName);
            SqlParameter parametr2 = new SqlParameter("@Surname", FindSurname);
            SqlParameter parametr3 = new SqlParameter("@Age", Age);
            SqlParameter parametr4 = new SqlParameter("@Course", Course);
 
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
        public ActionResult GroupResult(string NameOfGroup, int? CountOfUsers)
        {
           if(CountOfUsers == null)
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