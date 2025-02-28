using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MemberObject
    {

        private readonly IMemberRepository memberRepository;
        public static Member? AccountLogin { get; set; }

        public MemberObject()
        {
            memberRepository = new MemberRepository(); //dependence contruction
        }

        public bool Login(string email, string password)
        {
            Member member = memberRepository.FindMember(email, password);
            if(member == null)
            {
                return false;
            }
            AccountLogin = member;
            return true;
        }
    }
}
