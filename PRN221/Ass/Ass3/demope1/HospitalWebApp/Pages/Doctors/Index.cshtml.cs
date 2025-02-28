using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HospitalBusiness;

namespace HospitalWebApp.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly HospitalBusiness.AppDbContext _context;

        public IndexModel(HospitalBusiness.AppDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; } = default!;
        //search
        public string? SearchString { get; set; }

        public async Task OnGetAsync(string? searchString)
        {
            // Store search string for display in view
            SearchString = searchString;

            // Query patients with optional filtering and ordering
            IQueryable<Doctor> doctorIQ = from p in _context.Doctors
                                            select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                doctorIQ = doctorIQ.Where(p => p.DoctorName.Contains(SearchString));
            }

            // Order patients in descending order by name
            Doctor = await doctorIQ.OrderByDescending(p => p.DoctorName).ToListAsync();
        }
    }
}