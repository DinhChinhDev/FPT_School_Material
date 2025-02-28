using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private readonly MemberRepository _memberRepository;

        public MemberDAO(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member GetMemberById(int memberId)
        {
            return _memberRepository.GetById(memberId);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAll();
        }

        public void AddMember(Member member)
        {
            _memberRepository.InspectMember(member);
        }

        public void UpdateMember(Member member)
        {
            _memberRepository.UpdateMember(member);
        }

        public void DeleteMember(int memberId)
        {
            var member = _memberRepository.GetById(memberId);
            if (member != null)
                _memberRepository.DeleteMember(memberId);
        }

        public Member AuthenMember(string email, string password)
        {
            Member member = GetAllMembers().FirstOrDefault(m => m.Email == email && m.Password == password);
            return member;
        }

    }
}
