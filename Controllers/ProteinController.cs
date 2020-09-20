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
    public class ProteinController : Controller
    {
        //
        // GET: /Protein/

        //
        // GET: /Protein/
        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {

            List<ProteinViewModel> lstprotein = new List<ProteinViewModel>();
            var proteins = db.tblProteins.ToList();
            foreach (var item in proteins)
            {
                lstprotein.Add(new ProteinViewModel() {ProteinId=item.ProteinId,ProteinName=item.ProteinName, Price=item.Price, Description=item.Description });
            }
            return View(lstprotein);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Add(ProteinViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<ProteinViewModel> lstprotein = new List<ProteinViewModel>();
                if (ModelState.IsValid)
                {
                    tblProtein tb = new tblProtein();
                    tb.ProteinName = model.ProteinName;
                    tb.Price = model.Price;
                    tb.Description = model.Description;

                    db.tblProteins.Add(tb);
                    db.SaveChanges();


                    ViewBag.Message = "Protein Added";
                }
            }
            return View();


        }
        public ActionResult Edit(int id)
        {
            ProteinViewModel pro = new ProteinViewModel();
            tblProtein tb = db.tblProteins.Where(t => t.ProteinId == id).FirstOrDefault();
            pro.ProteinId = tb.ProteinId;
            pro.ProteinName = tb.ProteinName;
            pro.Price = tb.Price;
            pro.Description = tb.Description;
            return View(pro);
        }
        [HttpPost]

        public ActionResult Edit(ProteinViewModel model)
        {
            if (ModelState.IsValid)
            {

                
                tblProtein pro = db.tblProteins.Where(t => t.ProteinId == model.ProteinId).FirstOrDefault();
                pro.ProteinId = model.ProteinId;
                pro.ProteinName = model.ProteinName;
                pro.Price = model.Price;
                pro.Description = model.Description;
                db.SaveChanges();
                ViewBag.Message = "Protein Updated";
            }

            return View();

        }
        public ActionResult Delete(int id)
        {
            ProteinViewModel pro = new ProteinViewModel();
            tblProtein tb = db.tblProteins.Where(t => t.ProteinId == id).FirstOrDefault();
            pro.ProteinId = tb.ProteinId;
            pro.ProteinName = tb.ProteinName;
            pro.Price = tb.Price;
            pro.Description = tb.Description;
            return View(pro);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            db.tblProteins.Remove(db.tblProteins.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
