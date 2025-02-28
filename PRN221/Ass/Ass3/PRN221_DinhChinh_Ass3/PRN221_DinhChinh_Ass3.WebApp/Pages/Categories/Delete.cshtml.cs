using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;

namespace PRN221_DinhChinh_Ass3.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext _context;

        public DeleteModel(PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Caterories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Caterories.FindAsync(id);
            if (category != null)
            {
                Category = category;
                _context.Caterories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
