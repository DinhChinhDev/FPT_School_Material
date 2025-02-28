using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using PRN221_DinhChinh_Ass3.WebApp.Filter;

namespace PRN221_DinhChinh_Ass3.WebApp.Pages.Books
{
    [SessionAuthorize("Admin")]
    public class CreateModel : PageModel
    {
        private readonly PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext _context;

        public CreateModel(PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Caterories, "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
