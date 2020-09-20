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
    public class MeasurementController : Controller
    {
        //
        // GET: /Measurement/

        //
        // GET: /Measurement/

        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {
            List<MeasurementViewModel> lstmvm = new List<MeasurementViewModel>();
            var measures = db.tblMeasurements.ToList();
            foreach (var item in measures)
            {
                tblMembership tb = db.tblMemberships.Where(m => m.MembershipId == item.MemberId).FirstOrDefault();
                tblUser tbu = db.tblUsers.Where(k => k.UserId == tb.UserId).FirstOrDefault();
                lstmvm.Add(new MeasurementViewModel() {MeasurementId=item.MeasurementId,Fullname=tbu.Fullname, MemberId=item.MemberId,Weight=item.Weight, Chest=item.Chest,Weist=item.Weist, Hip=item.Hip, Thigh=item.Thigh, Bicep=item.Bicep,Forearm=item.Forearm,MeasurementDate=item.MeasurementDate });
            }
            return View(lstmvm);
        }
        public ActionResult Add()
        {
           List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

            var users = db.tblUsers.ToList();
            foreach (var item in users)
            {
                tblMembership tbm = db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                if (tbm != null)
                {
                    lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                }

            }
            MeasurementViewModel mv = new MeasurementViewModel();
            mv.MeasurementDate = DateTime.Today;
            ViewBag.Fullname = lstmemvm;
            return View(mv);
        }
        [HttpPost]


       
        public ActionResult Add(MeasurementViewModel model)
        {
            if (ModelState.IsValid)
            {
                tblMeasurement tb = new tblMeasurement();
                tb.MemberId = model.MemberId;
                tb.Weight = model.Weight;
                tb.Chest = model.Chest;
                tb.Weist = model.Weist;
                tb.Hip = model.Hip;
                tb.Thigh = model.Thigh;
                tb.Bicep = model.Bicep;
                tb.Forearm = model.Forearm;
                tb.MeasurementDate = model.MeasurementDate;
                db.tblMeasurements.Add(tb);
                db.SaveChanges();
                ViewBag.Message = "Measurement Added";

            }
            List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

            var users = db.tblUsers.ToList();
            foreach (var item in users)
            {
                tblMembership tbm = db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                if (tbm != null)
                {
                    lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                }
            }
            ViewBag.Message = "Measurement Added Successfully";
            ViewBag.Fullname = lstmemvm;
            return View();

        }
        public ActionResult Edit(int id)
        {
            MeasurementViewModel tb = new MeasurementViewModel();
            tblMeasurement model = db.tblMeasurements.Where(m => m.MeasurementId == id).FirstOrDefault();
            tb.MeasurementId = model.MeasurementId;
            tb.MemberId = model.MemberId;
            tb.Weight = model.Weight;
            tb.Chest = model.Chest;
            tb.Weist = model.Weist;
            tb.Hip = model.Hip;
            tb.Thigh = model.Thigh;
            tb.Bicep = model.Bicep;
            tb.Forearm = model.Forearm;
            tb.MeasurementDate = model.MeasurementDate;


            List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

            var users = db.tblUsers.Where(u=>u.Usertype=="User").ToList();
            foreach (var item in users)
            {
                tblMembership tbm = db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                if (tbm != null)
                {
                    lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                }
            }
            ViewBag.Fullname = lstmemvm;
           
           
            return View(tb);
        }

        [HttpPost]
        public ActionResult Edit(tblMeasurement model)
        {
            if (ModelState.IsValid)
            {
                tblMeasurement tb = db.tblMeasurements.Where(m => m.MeasurementId == model.MeasurementId).FirstOrDefault();
                tb.MemberId = model.MemberId;
                tb.Weight = model.Weight;
                tb.Chest = model.Chest;
                tb.Weist = model.Weist;
                tb.Hip = model.Hip;
                tb.Thigh = model.Thigh;
                tb.Bicep = model.Bicep;
                tb.Forearm = model.Forearm;
                tb.MeasurementDate = model.MeasurementDate;
              
                db.SaveChanges();
                

                List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

                var users = db.tblUsers.ToList();
                foreach (var item in users)
                {
                    tblMembership tbm = db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                    if (tbm != null)
                    {

                        lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                    }
                }
                ViewBag.Fullname = lstmemvm;

                ViewBag.Message = "Measurement Updated";
            }
            return View(); ;
        }

        public ActionResult Delete(int id)
        {

            db.tblMeasurements.Remove(db.tblMeasurements.Find(id));
            db.SaveChanges();
            return View();
        }


    }
}
