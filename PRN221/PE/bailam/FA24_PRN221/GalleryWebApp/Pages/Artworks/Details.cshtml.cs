using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Artworks
{
    public class DetailsModel : PageModel
    {
        private readonly GalleryBusiness.AppDbContext _context;

        public DetailsModel(GalleryBusiness.AppDbContext context)
        {
            _context = context;
        }

        public Artwork Artwork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks.FirstOrDefaultAsync(m => m.ArtworkId == id);
            if (artwork == null)
            {
                return NotFound();
            }
            else
            {
                Artwork = artwork;
            }
            return Page();
        }
    }
}
