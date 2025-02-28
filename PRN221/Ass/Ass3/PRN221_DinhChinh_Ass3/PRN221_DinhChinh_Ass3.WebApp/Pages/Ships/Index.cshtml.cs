using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using PRN221_DinhChinh_Ass3.WebApp.Filter;

namespace PRN221_DinhChinh_Ass3.WebApp.Pages.Ships
{
    [SessionAuthorize("Admin")]
    public class IndexModel : PageModel
    {
        private readonly PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext _context;

        public IndexModel(PRN221_DinhChinh_Ass3.DataAccess.Repository.AppDbContext context)
        {
            _context = context;
        }

        public IList<Ship> Ship { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ship = await _context.Ships
                .Include(s => s.Book)
                .Include(s => s.UserOrder)
                .Include(s => s.UserShip).ToListAsync();
        }
    }
}
