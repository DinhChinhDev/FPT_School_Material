using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryBusiness
{
    public class Exhibition
    {
        public int ExhibitionId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public string? Description { get; set; } = string.Empty;
    }
}



