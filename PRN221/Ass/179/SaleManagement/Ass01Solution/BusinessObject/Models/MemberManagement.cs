using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class MemberManagement
    {
        private static MemberManagement instance = null;
        public static readonly object instanceLock = new object();

        private MemberManagement() { }  
        public static MemberManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberManagement();
                    }
                    return instance;
                }
            }
        }

        internal Member GetMemberByUserPass(string user, string pass)
        {
            Member member = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                member = myContextDB.Members.FirstOrDefault(item => item.Email.Equals(user) && item.Password.Equals(pass));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public IEnumerable<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var myContextDB = new PRN221_As01Context();
                members = myContextDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByID(int id)
        {
            Member member = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                member = myContextDB.Members.SingleOrDefault(item => item.MemberId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddNew(Member member)
        {
            try
            {
                Member currentMember = GetMemberByID(member.MemberId);
                if (currentMember == null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Members.Add(member);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                Member currentMember = GetMemberByID(member.MemberId);
                if (currentMember != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Entry(member).State = EntityState.Modified;
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Member member)
        {
            try
            {
                Member currentMember = GetMemberByID(member.MemberId);
                if (currentMember != null)
                {
                    var myContextDB = new PRN221_As01Context();
                    myContextDB.Members.Remove(member);
                    myContextDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
