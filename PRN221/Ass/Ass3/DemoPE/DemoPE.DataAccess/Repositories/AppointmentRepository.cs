using DemoPE.DataAccess.Data;
using DemoPE.DataAccess.Repositories.IRepositories;
using DemoPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataAccess.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public AppointmentRepository(AppDbContext db): base(db) { }
    }
}
