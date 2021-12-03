using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_RazorContoso.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(8)]
        [RegularExpression("[A-Z{2}[0-9]{1}[A-Z]{3}[0-9]{1}")]
        public string CourseID { get; set; }

        [StringLength(30), Required, MinLength(10)]
        public string Title { get; set; }

        // navigation properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
