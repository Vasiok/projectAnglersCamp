using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MembersDb
    {
         private AnglersCampEntities db;

        public MembersDb()
        {
            db = new AnglersCampEntities();
        }

        public IEnumerable<Member> GetAll()
        {
            return db.Members.ToList();
        }

        public Member GetById(int id)
        {
            return db.Members.Find(id);
        }

        public void Insert(Member member)
        {
            db.Members.Add(member);
            Save();
        }

        public void Delete(int id)
        {
            Member mem = db.Members.Find(id);

            db.Members.Remove(mem);

            Save();
        }

        public void Update(Member member)
        {
            db.Entry(member).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;

            Save();

            db.Configuration.ValidateOnSaveEnabled = true;
        }

        void Save()
        {
            db.SaveChanges();
        }

    }
}
