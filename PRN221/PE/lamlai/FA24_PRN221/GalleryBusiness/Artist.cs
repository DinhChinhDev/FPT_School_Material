using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryBusiness
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string? Name { get; set;} = string.Empty;
        public string? Biography { get; set; } = string.Empty;
    }
}
