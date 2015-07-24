using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WaterLevelDb
    {
        private AnglersCampEntities db;

        public WaterLevelDb()
        {
            db = new AnglersCampEntities();
        }

        public IEnumerable<WaterLevel> GetAll()
        {
            return db.WaterLevels.ToList();
        }

        public List<WaterLevel> GetAllAsList()
        {
            return db.WaterLevels.ToList();
        }

        public WaterLevel GetById(int id)
        {
            return db.WaterLevels.Find(id);
        }

        public void Insert(WaterLevel waterLevel)
        {
            db.WaterLevels.Add(waterLevel);
            Save();
        }

        public void Delete(int id)
        {
            WaterLevel lvl = db.WaterLevels.Find(id);

            db.WaterLevels.Remove(lvl);

            Save();
        }

        public void Update(WaterLevel waterLevel)
        {
            db.Entry(waterLevel).State = EntityState.Modified;
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
