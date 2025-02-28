using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HospitalBusiness;

namespace HospitalWebApp.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly HospitalBusiness.AppDbContext _context;

        public IndexModel(HospitalBusiness.AppDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;
        //search
        public string? SearchString { get; set; }

        public async Task OnGetAsync(string? searchString)
        {
            // Store search string for display in view
            SearchString = searchString;

            // Query patients with optional filtering and ordering
            IQueryable<Patient> patientIQ = from p in _context.Patients
                                            select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                patientIQ = patientIQ.Where(p => p.PatientName.Contains(SearchString));
            }

            // Order patients in descending order by name
            Patient = await patientIQ.OrderByDescending(p => p.PatientName).ToListAsync();
        }
    }
}