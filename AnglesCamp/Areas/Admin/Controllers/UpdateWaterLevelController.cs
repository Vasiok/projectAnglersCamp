using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Admin.Controllers
{

    [Authorize(Roles="A")]
    public class UpdateWaterLevelController : Controller
    {

        private WaterlevelBs objBs;

        public UpdateWaterLevelController()
        {            

            objBs = new WaterlevelBs();
        }
        // GET: Admin/UpdateWaterLevel
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

            levels = levels.Skip((page -1)*20).Take(20);

            return View(levels);            
        }

        
        public ActionResult Update()
        {

            try
            {
                WaterLevelJson lvl = new WaterLevelJson();

                var resultFromNet = lvl.GetFromKimono();

                objBs.UpdateOrCreate(resultFromNet);
                TempData["Msg"] = "Water levels updated Successfuly";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Water levels update Failed " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            WaterLevel lvl = objBs.GetById(id);

            return View(lvl);
        }


        [HttpPost]
        public ActionResult Edit(WaterLevel lvl)
        {
            try
            {
                objBs.Update(lvl);

                TempData["Msg"] = "Acceptable water level updated successfully";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Update failed" + e.Message;
                return RedirectToAction("Index");
            }
           
        }
    }
}