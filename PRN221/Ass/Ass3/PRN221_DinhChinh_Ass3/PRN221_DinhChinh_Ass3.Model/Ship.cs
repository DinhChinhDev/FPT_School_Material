using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_DinhChinh_Ass3.Model
{
    public class Ship
    {
        public int ShipId {  get; set; }
        public DateTime DateOrder { get; set; } = DateTime.Now;
        public DateTime DateShip { get; set; }
        public int? BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }

        public int? UserOrderId { get; set; }
        [ForeignKey(nameof(UserOrderId))]
        public AppUser? UserOrder { get; set; }
        public int? UserShipId { get; set; }
        [ForeignKey(nameof(UserShipId))]
        public AppUser? UserShip { get; set; }



    }
}
