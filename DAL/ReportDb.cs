using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportDb
    {
         private AnglersCampEntities db;

        public ReportDb()
        {
            db = new AnglersCampEntities();
        }

        public IEnumerable<Report> GetAll()
        {
            return db.Reports.ToList();
        }

        public Report GetById(int id)
        {
            return db.Reports.Find(id);
        }

        public void Insert(Report report)
        {
            db.Reports.Add(report);
            Save();
        }

        public void Delete(int id)
        {
            Report rep = db.Reports.Find(id);

            db.Reports.Remove(rep);

            Save();
        }

        public void Update(Report report)
        {
            db.Entry(report).State = EntityState.Modified;
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
