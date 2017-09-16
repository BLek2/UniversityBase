using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityBase.Models
{
    public class Group
    {
       [Key]
       [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
       [Required(ErrorMessage = "Field is required")]
       public string NameOfGroup { get; set; }
       public int? CountOfUsers { get; set; }
       public ICollection<Student> Students { get; set; }
       public Group()
        {
            Students = new List<Student>();
        }
    }
}