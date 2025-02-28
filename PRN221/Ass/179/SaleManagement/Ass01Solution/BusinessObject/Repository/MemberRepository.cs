using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member)
        {
            MemberManagement.Instance.Remove(member);
        }

        public Member GetMemberByID(int id)
        {
            return MemberManagement.Instance.GetMemberByID(id);
        }

        public Member GetMemberByUserPass(string user, string pass)
        {
            return MemberManagement.Instance.GetMemberByUserPass( user, pass);
        }

        public IEnumerable<Member> GetMembers()
        {
            return MemberManagement.Instance.GetMemberList();
        }

        public void InsertMember(Member member)
        {
            MemberManagement.Instance.AddNew(member);
        }

        
        public void UpdateMember(Member member)
        {
            MemberManagement.Instance.Update(member);
        }

       
    }
}
