using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public List<Member> GetAll();
        public Member GetById(int id);
        public void DeleteMember(int id);
        public void UpdateMember(Member member);
        public void InspectMember(Member member);
        public Member FindMember(string email, string password);
    }
}
