using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityBase.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(20,MinimumLength =2,ErrorMessage = "Enter from 2 to 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter from 2 to 20 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime AgeOfBirth { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Range(1,6,ErrorMessage = "Invalid course")]
        public int Course { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Range(5,500,ErrorMessage = "Invalid age")]
        public int Age { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}