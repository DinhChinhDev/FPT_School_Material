using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_DinhChinh_Ass3.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = String.Empty;
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
