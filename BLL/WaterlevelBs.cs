using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class WaterlevelBs
    {
        // Regex used to extract the water levels value only from table        
        private string EXPRESSION = ConfigurationManager.AppSettings["WaterLevel"].ToString();
        private WaterLevelDb objDb;

        public WaterlevelBs()
        {
            objDb = new WaterLevelDb();
        }

        public IEnumerable<WaterLevel> GetAll()
        {
            return objDb.GetAll();
        }


        public void UpdateOrCreate(List<JSONModel> models)
        {
            List<WaterLevel> fromDb = GetAll().ToList();

            foreach (JSONModel item in models)
            {                

                List<WaterLevel> comapreResult = fromDb.Where(db => db.County == item.County && db.WaterBody == item.WaterBody && db.Name == item.Name.text).ToList();

                if (!comapreResult.Any())
                {
                    WaterLevel lvl = new WaterLevel();
                    lvl.Name = item.Name.text;
                    lvl.County = item.County;
                    if (item.WaterLevel == null || item.WaterLevel == "")
                    {
                        lvl.WaterLevel1 = "Default (0.000 m)";
                        lvl.AWaterLevel = "Default (0.000 m)";
                    }
                    else
                    {
                        lvl.AWaterLevel = item.WaterLevel;
                        lvl.WaterLevel1 = item.WaterLevel;
                    }                    
                    lvl.URL = item.Name.href;
                    lvl.WaterBody = item.WaterBody;

                    Insert(lvl);
                }                
                else
                {
                    WaterLevel lvl = fromDb.First(l => l.County == item.County && l.WaterBody == item.WaterBody && l.Name == item.Name.text);                   

                    lvl.WaterLevel1 = item.WaterLevel;

                    if (lvl.WaterLevel1 == null || lvl.WaterLevel1 == "")
                    {
                        lvl.WaterLevel1 = "Default (0.000 m)";
                        lvl.AWaterLevel = "Default (0.000 m)";
                    }

                    Update(lvl);
                }
            }
        }


        public IEnumerable<WaterLevel> GetAllReady()
        {
            List<WaterLevel> levels = objDb.GetAllAsList();

            for(int i = 0; i < levels.Count(); i++)
            {
                if (levels[i].County == "" || levels[i].County == null)
                {
                    levels[i].County = "Unknown";
                }

                Match matchOne = Regex.Match(levels[i].WaterLevel1, EXPRESSION);
                Match matchTwo = Regex.Match(levels[i].AWaterLevel, EXPRESSION);

                if (matchOne.Success && matchTwo.Success)
                {
                    string currentLevel = matchOne.Groups[0].Value;
                    string aLevel = matchTwo.Groups[0].Value;

                    currentLevel = currentLevel.Substring(1, 6);

                    if (currentLevel[0] == '-')
                    {
                        currentLevel = currentLevel.Substring(1, 5);
                    }

                    aLevel = aLevel.Substring(1, 6);
                    if (aLevel[0] == '-')
                    {
                        aLevel = aLevel.Substring(1, 5);
                    }

                    if (double.Parse(currentLevel) > double.Parse(aLevel))
                    {
                        levels[i].AWaterLevel = "HIGH WATER";
                    }
                    else
                    {
                        levels[i].AWaterLevel = "GOOD";
                    }

            }
            
          }

          return levels;

        }//EndOf GetAllReady()





        public WaterLevel GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(WaterLevel level)
        {
            objDb.Insert(level);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(WaterLevel level)
        {
            objDb.Update(level);
        }
    }
}
