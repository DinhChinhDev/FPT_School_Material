using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly GalleryBusiness.AppDbContext _context;

        public IndexModel(GalleryBusiness.AppDbContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Artist = await _context.Artists.ToListAsync();
        }
    }
}
