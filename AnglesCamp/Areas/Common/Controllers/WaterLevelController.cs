using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class WaterLevelController : Controller
    {

        private WaterlevelBs objBs;
        public WaterLevelController()
        {
            objBs = new WaterlevelBs();
        }

        // GET: Common/WaterLevel
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy; 

            var levels = objBs.GetAllReady();

            switch (SortBy)
            {
                case "County":
                    switch (SortOrder)
                    {
                        case "ASC":
                            levels = levels.OrderBy(l => l.County).ToList();
                            break;
                        case "DESC":
                            levels = levels.OrderByDescending(l => l.County).ToList();
                            break;

                        default:
                            break;
                    }
                    break;


                case "Name":
                    switch (SortOrder)
                    {
                        case "ASC":
                            levels = levels.OrderBy(l => l.Name).ToList();
                            break;
                        case "DESC":
                            levels = levels.OrderByDescending(l => l.Name).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Water Body":
                    switch (SortOrder)
                    {
                        case "ASC":
                            levels = levels.OrderBy(l => l.WaterBody).ToList();
                            break;
                        case "DESC":
                            levels = levels.OrderByDescending(l => l.WaterBody).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Current Level":
                    switch (SortOrder)
                    {
                        case "ASC":
                            levels = levels.OrderBy(l => l.WaterLevel1).ToList();
                            break;
                        case "DESC":
                            levels = levels.OrderByDescending(l => l.WaterLevel1).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Fishable":
                    switch (SortOrder)
                    {
                        case "ASC":
                            levels = levels.OrderBy(l => l.AWaterLevel).ToList();
                            break;
                        case "DESC":
                            levels = levels.OrderByDescending(l => l.AWaterLevel).ToList();
                            break;

                        default:
                            break;
                    }
                    break;



                default:
                    levels = levels.OrderBy(l => l.County).ToList();
                    break;
            }


            ViewBag.TotalPages = Math.Ceiling(objBs.GetAllReady().Count() / 20.0);

            int page = int.Parse(Page == null ? "1" : Page);

            ViewBag.Page = page;

            levels = levels.Skip((page - 1) * 20).Take(20);

            return View(levels);
        }
    }
}