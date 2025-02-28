using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoPE.DataAccess.Data;
using DemoPE.Models;

namespace DemoPE.WebApp.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly DemoPE.DataAccess.Data.AppDbContext _context;

        public DetailsModel(DemoPE.DataAccess.Data.AppDbContext context)
        {
            _context = context;
        }

        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                Doctor = doctor;
            }
            return Page();
        }
    }
}
