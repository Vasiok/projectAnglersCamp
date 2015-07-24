using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportBs
    {
        private ReportDb objDb;

        public ReportBs()
        {
            objDb = new ReportDb();
        }

        public IEnumerable<Report> GetAll()
        {
            return objDb.GetAll();
        }

        public Report GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(Report report)
        {
            objDb.Insert(report);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(Report report)
        {
            objDb.Update(report);
        }
    }
}
