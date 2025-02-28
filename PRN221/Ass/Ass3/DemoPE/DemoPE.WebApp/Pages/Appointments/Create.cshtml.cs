using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoPE.DataAccess.Data;
using DemoPE.Models;

namespace DemoPE.WebApp.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly DemoPE.DataAccess.Data.AppDbContext _context;

        public CreateModel(DemoPE.DataAccess.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "Name");
        ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
