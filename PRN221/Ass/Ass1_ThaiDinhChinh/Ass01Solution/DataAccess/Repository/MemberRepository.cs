using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                Member? deletedMember = context.Members.FirstOrDefault(m => m.MemberId == id) ?? throw new Exception("No member was found!");
                context.Members.Remove(deletedMember);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Member FindMember(string email, string password)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Members.FirstOrDefault(m => m.Email == email && m.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Member> GetAll()
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Members.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Member GetById(int id)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                return context.Members.FirstOrDefault(m => m.MemberId == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InspectMember(Member member)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Members.Add(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                using var context = new DinhChinhFstoreContext();
                context.Entry(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
