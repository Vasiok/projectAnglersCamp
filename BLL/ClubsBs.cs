using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClubsBs
    {

        private ClubsDb objDb;

        public ClubsBs()
        {
            objDb = new ClubsDb();
        }
        

        public IEnumerable<Club> GetAll()
        {
            return objDb.GetAll();
        }

        public Club GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(Club club)
        {
            objDb.Insert(club);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(Club club)
        {
            objDb.Update(club);
        }

    }
}
