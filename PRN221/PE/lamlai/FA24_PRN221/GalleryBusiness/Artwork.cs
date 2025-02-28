using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryBusiness
{
    public class Artwork
    {
        public int ArtworkId { get; set; }
        public string? Title { get; set; } = string.Empty;  
        public int? Year { get; set; }
        public int? Medium { get; set; }

        public int? ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist? Artist { get; set; }

        public int? ExhibitionId { get; set; }
        [ForeignKey(nameof(ExhibitionId))]
        public Exhibition? Exhibition { get; set; }
    }
}
