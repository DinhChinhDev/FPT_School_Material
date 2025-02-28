using DemoPE.DataAccess.Data;
using DemoPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataAccess.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>
    {
        public DoctorRepository(AppDbContext db) : base(db) { }
    }
}
