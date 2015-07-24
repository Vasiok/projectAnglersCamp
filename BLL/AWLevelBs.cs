using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AWLevelBs
    {

        private AWLevelDb objDb;

        public AWLevelBs()
        {
            objDb = new AWLevelDb();
        }

        public IEnumerable<ALevelRport> GetAll()
        {
            return objDb.GetAll();
        }

        public ALevelRport GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(ALevelRport lvl)
        {
            objDb.Insert(lvl);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(ALevelRport lvl)
        {
            objDb.Update(lvl);
        }

    }
}
