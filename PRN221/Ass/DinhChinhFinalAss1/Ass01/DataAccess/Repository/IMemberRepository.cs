using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Member GetById(int id);
        IEnumerable<Member> GetAll();
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
    }
}
