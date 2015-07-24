using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AWLevelDb
    {

        private AnglersCampEntities db;

        public AWLevelDb()
        {
            db = new AnglersCampEntities();
        }

        public IEnumerable<ALevelRport> GetAll()
        {
            return db.ALevelRports.ToList();
        }

        public ALevelRport GetById(int id)
        {
            return db.ALevelRports.Find(id);
        }

        public void Insert(ALevelRport lvl)
        {
            db.ALevelRports.Add(lvl);
            Save();
        }

        public void Delete(int id)
        {
            ALevelRport lvl = db.ALevelRports.Find(id);

            db.ALevelRports.Remove(lvl);

            Save();
        }

        public void Update(ALevelRport lvl)
        {
            db.Entry(lvl).State = EntityState.Modified;
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
