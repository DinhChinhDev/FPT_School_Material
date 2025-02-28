using DemoPE.DataAccess.Data;
using DemoPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataAccess.Repositories
{
    public class PatientRepository :GenericRepository<Patient>
    {
        public PatientRepository(AppDbContext db) : base(db) { }
    }
}
