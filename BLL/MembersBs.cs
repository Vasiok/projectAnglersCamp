using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MembersBs
    {
        private MembersDb objDb;

        public MembersBs()
        {
            objDb = new MembersDb();
        }

        public IEnumerable<Member> GetAll()
        {
            return objDb.GetAll();
        }

        public Member GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(Member member)
        {
            objDb.Insert(member);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(Member member)
        {
            objDb.Update(member);
        }


    }
}
