using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void Delete(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return _context.Members.Find(id);
        }

        public void Update(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
