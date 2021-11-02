using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_RazorContoso.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public string CorseCose { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        // navigation properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
