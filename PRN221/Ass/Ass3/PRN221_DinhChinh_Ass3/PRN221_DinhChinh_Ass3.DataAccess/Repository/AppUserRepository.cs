using PRN221_DinhChinh_Ass3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_DinhChinh_Ass3.DataAccess.Repository
{
    public class AppUserRepository : GenericRepository<AppUser>
    {
        public AppUserRepository(AppDbContext db) : base(db) { }
    }
}
