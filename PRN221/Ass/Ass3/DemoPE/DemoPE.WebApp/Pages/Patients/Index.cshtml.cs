using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoPE.DataAccess.Data;
using DemoPE.Models;

namespace DemoPE.WebApp.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly DemoPE.DataAccess.Data.AppDbContext _context;

        public IndexModel(DemoPE.DataAccess.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients.ToListAsync();
        }
    }
}
