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
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/
        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {
            List<GalleryViewModel> lstgall = new List<GalleryViewModel>();
            var tb = db.tblGalleries.ToList();
            foreach (var item in tb)
            {
                lstgall.Add(new GalleryViewModel() { GalleryId = item.GalleryId, Title = item.Title, Description = item.Description, Photo = item.Photo });
            }
            return View(lstgall);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult Add(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                tblGallery tb = new tblGallery();
                tb.Title = model.Title;
                tb.Description = model.Description;
                HttpPostedFileBase fup = Request.Files["Photo"];
                if (fup != null)
                {
                    tb.Photo = fup.FileName;
                    fup.SaveAs(Server.MapPath("~/Gallery/" + fup.FileName));
                }
               

                db.tblGalleries.Add(tb);
                db.SaveChanges();


                ViewBag.Message = "Photo Saved";
                

            }
           
            return View();

        }
        public ActionResult Edit(int id)
        {
            GalleryViewModel gvm = new GalleryViewModel();
            tblGallery tb = db.tblGalleries.Where(g => g.GalleryId == id).FirstOrDefault();
            gvm.GalleryId = tb.GalleryId;
            gvm.Title = tb.Title;
            gvm.Description = tb.Description;

            gvm.Photo = tb.Photo;
            return View(gvm);
        }

        [HttpPost]
        public ActionResult Edit(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                tblGallery tb = db.tblGalleries.Where(g => g.GalleryId == model.GalleryId).FirstOrDefault();
                tb.GalleryId = model.GalleryId;
                tb.Title = model.Title;
                tb.Description = model.Description;
                HttpPostedFileBase fup = Request.Files["Photo"];
                if (fup != null && fup.FileName!="")
                {
                    tb.Photo = fup.FileName;
                    fup.SaveAs(Server.MapPath("~/Gallery/" + fup.FileName));
                }
                else
                {
                    tb.Photo = model.Photo;
                }
                
                db.SaveChanges();
                ViewBag.Message = "Gallery Updated";
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            GalleryViewModel gvm = new GalleryViewModel();
            tblGallery tb = db.tblGalleries.Where(g => g.GalleryId == id).FirstOrDefault();
            gvm.GalleryId = tb.GalleryId;
            gvm.Title = tb.Title;
            gvm.Description = tb.Description;

            gvm.Photo = tb.Photo;
            return View(gvm);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            
            tblGallery tb = db.tblGalleries.Where(g => g.GalleryId == id).FirstOrDefault();
            db.tblGalleries.Remove(tb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
