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
    public class MembershipTypeController : Controller
    {
        //
        // GET: /MembershipType/

       

        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {
            return View(db.tblMembershipTypes.ToList());
        }
        public ActionResult Add()
        {
            return PartialView();
        }


        [HttpPost]
      
       
        public ActionResult Add(MembershipTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                tblMembershipType tb = new tblMembershipType();
                tb.MembershipName = model.MembershipName;
                tb.Price = model.Price;

                db.tblMembershipTypes.Add(tb);
                db.SaveChanges();
                return PartialView("_Details", db.tblMembershipTypes.ToList());
                
            }
            return PartialView("Add", db.tblMembershipTypes.ToList());
            
        }
        public ActionResult Edit(int id)
        {
            return PartialView(db.tblMembershipTypes.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(tblMembershipType model, int id)
        {
            if (ModelState.IsValid)
            {

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView("_Details", db.tblMembershipTypes.ToList());
        }

        public ActionResult Delete(int id)
        {

            db.tblMembershipTypes.Remove(db.tblMembershipTypes.Find(id));
            db.SaveChanges();
            return PartialView("_Details", db.tblMembershipTypes.ToList());
        }


    }
}
