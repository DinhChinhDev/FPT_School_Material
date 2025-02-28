using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HospitalBusiness;

namespace HospitalWebApp.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly HospitalBusiness.AppDbContext _context;

        public IndexModel(HospitalBusiness.AppDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient).ToListAsync();
        }
    }
}
