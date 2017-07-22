using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityBase.Models
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public int? Math { get; set; }
        public int? History { get; set; }
        public int? Psychology { get; set; }
        public int? Literature { get; set; }
        public int? Cooking { get; set; }
        public int? Music { get; set; }
        public int? Law { get; set; }
        public int? Programming { get; set; }
        public int? WebDesign { get; set; }
        
    }
}