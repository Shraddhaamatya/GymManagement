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
    public class AttendanceController : Controller
    {
        GymDBEntities db = new GymDBEntities();
        public ActionResult Index()
        {
            
            return View(db.tblAttendances.ToList());
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
            ViewBag.Fullname = lstmemvm;
            AttendanceViewModel atvm = new AttendanceViewModel();
           string todate= DateTime.Now.ToString("MM/dd/yyyy");
           atvm.AttendanceDate = Convert.ToDateTime(todate);
           
            return View(atvm);
        }
        [HttpPost]

        public ActionResult Add(AttendanceViewModel atv)
        {
            if (ModelState.IsValid)
            {
                tblAttendance tbat = db.tblAttendances.Where(a => a.MemberId == atv.MemberId && a.AttendanceDate == DateTime.Today).FirstOrDefault();
                if (tbat != null)
                {
                    ViewBag.Message = "Attendance Already Done";
                }
                else
                {

                    tblAttendance tb = new tblAttendance();

                    tb.MemberId = atv.MemberId;
                    tb.Status = atv.Status;
                    tb.AttendanceDate = atv.AttendanceDate;
                    db.tblAttendances.Add(tb);
                    db.SaveChanges();

                    ViewBag.Message = "Attendance Done Successfully";
                }
               
            }

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
            return View();

        }
        public ActionResult Edit(int id)
        {
            return PartialView(db.tblAttendances.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(tblAttendance model, int id)
        {
            if (ModelState.IsValid)
            {

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView("_Details", db.tblAttendances.ToList());
        }

        public ActionResult Delete(int id)
        {

            db.tblAttendances.Remove(db.tblAttendances.Find(id));
            db.SaveChanges();
            return PartialView("_Details", db.tblAttendances.ToList());
        }

    }
}
