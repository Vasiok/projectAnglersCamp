using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClubsDb
    {

        private AnglersCampEntities db;

        public ClubsDb()
        {
            db = new AnglersCampEntities();
        }

        public IEnumerable<Club> GetAll()
        {
            return db.Clubs.ToList();
        }

        public Club GetById(int id)
        {
            return db.Clubs.Find(id);
        }

        public void Insert(Club club)
        {
            db.Clubs.Add(club);
            Save();
        }

        public void Delete(int id)
        {
            Club clb = db.Clubs.Find(id);

            db.Clubs.Remove(clb);

            Save();
        }

        public void Update(Club clubs)
        {
            db.Entry(clubs).State = EntityState.Modified;
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
