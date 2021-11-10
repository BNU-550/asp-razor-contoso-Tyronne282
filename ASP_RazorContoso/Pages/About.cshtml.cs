using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_RazorContoso.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_RazorContoso.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ASP_RazorContoso.Data.ApplicationDbContext _context;

        public AboutModel(ASP_RazorContoso.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Students { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            Students = await data.AsNoTracking().ToListAsync();
        }
    }
}
