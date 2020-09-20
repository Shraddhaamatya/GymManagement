using GymManagement.Models;
using GymManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymManagement.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        //
        // GET: /Shift/

        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {
            List<ShiftViewModel> lstshitfs = new List<ShiftViewModel>();
            var shifts = db.tblShifts.ToList();
            foreach (var item in shifts)
            {
                lstshitfs.Add(new ShiftViewModel() { ShiftId = item.ShiftId, ShiftName = item.ShiftName, FromTime = item.FromTime, ToTime = item.ToTime });
            }
            return View(lstshitfs);
        }

        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        
        public ActionResult Add(ShiftViewModel model)
        {
            if (ModelState.IsValid)
            {
                tblShift ts = new tblShift();
                ts.ShiftName = model.ShiftName;
                ts.FromTime = model.FromTime;
                ts.ToTime = model.ToTime;
                db.tblShifts.Add(ts);
                db.SaveChanges();



                ViewBag.Message = "Shift Added";
            }
            return View();


        }
        public ActionResult Edit(int id)
        {
            ShiftViewModel shv = new ShiftViewModel();
            tblShift ts = db.tblShifts.Where(s => s.ShiftId == id).FirstOrDefault();
            shv.ShiftId = ts.ShiftId;
            shv.ShiftName = ts.ShiftName;
            shv.FromTime = ts.FromTime;
            shv.ToTime = ts.ToTime;
            return View(shv);
        }
        [HttpPost]
        
        public ActionResult Edit(ShiftViewModel model)
        {
            if (ModelState.IsValid)
            {

                tblShift ts = db.tblShifts.Where(s => s.ShiftId == model.ShiftId).FirstOrDefault();
                ts.ShiftName = model.ShiftName;
                ts.FromTime = model.FromTime;
                ts.ToTime = model.ToTime;
                
                db.SaveChanges();

                ViewBag.Message = "Shift Updated";

            }
           
            return View();

        }
        public ActionResult Delete(int id)
        {
            ShiftViewModel shv = new ShiftViewModel();
            tblShift ts = db.tblShifts.Where(s => s.ShiftId == id).FirstOrDefault();
            shv.ShiftId = ts.ShiftId;
            shv.ShiftName = ts.ShiftName;
            shv.FromTime = ts.FromTime;
            shv.ToTime = ts.ToTime;
            return View(shv);
        }

        [HttpPost,ActionName("Delete")]

        public ActionResult DeletePost(int id)
        {

            db.tblShifts.Remove(db.tblShifts.Find(id));
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }


    }
}
