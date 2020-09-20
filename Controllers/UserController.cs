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
    public class UserController : Controller
    {
        //
        // GET: /User/
        GymDBEntities _db = new GymDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProtein()
        {

            List<ProteinViewModel> lstprotein = new List<ProteinViewModel>();
            var proteins = _db.tblProteins.ToList();
            foreach (var item in proteins)
            {
                lstprotein.Add(new ProteinViewModel() { ProteinId = item.ProteinId, ProteinName = item.ProteinName, Price = item.Price, Description = item.Description });
            }
            return View(lstprotein);
        }
        public ActionResult ViewMeasurement()
        {
            int userid=Convert.ToInt32( Session["userid"].ToString());
            tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == userid).FirstOrDefault();
            




            List<MeasurementViewModel> lstmvm = new List<MeasurementViewModel>();
            var measures = _db.tblMeasurements.Where(m => m.MemberId == tbm.MembershipId).ToList();
            foreach (var item in measures)
            {
                tblMembership tb = _db.tblMemberships.Where(m => m.MembershipId == item.MemberId).FirstOrDefault();
                tblUser tbu = _db.tblUsers.Where(k => k.UserId == tb.UserId).FirstOrDefault();
                lstmvm.Add(new MeasurementViewModel() { MeasurementId = item.MeasurementId, Fullname = tbu.Fullname, MemberId = item.MemberId, Weight = item.Weight, Chest = item.Chest, Weist = item.Weist, Hip = item.Hip, Thigh = item.Thigh, Bicep = item.Bicep, Forearm = item.Forearm, MeasurementDate = item.MeasurementDate });
            }
            return View(lstmvm);
        }
        public ActionResult ViewPayment()
        {
            int userid = Convert.ToInt32(Session["userid"].ToString());
            tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == userid).FirstOrDefault();




            List<PaymentViewModel> lstmvm = new List<PaymentViewModel>();
            var payments = _db.tblPayments.Where(m => m.MemberId == tbm.MembershipId).ToList();
            foreach (var item in payments)
            {
               
                lstmvm.Add(new PaymentViewModel() { PaidAmount = item.PaidAmount, PaymentDate = item.PaymentDate});
            }
            return View(lstmvm);
        }
        public ActionResult ViewAttendance()
        {


            int userid = Convert.ToInt32(Session["userid"].ToString());
            tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == userid).FirstOrDefault();


            List<AttendanceViewModel> lstmvm = new List<AttendanceViewModel>();
            var attendance = _db.tblAttendances.Where(m => m.MemberId == tbm.MembershipId).ToList();
            foreach (var item in attendance)
            {

                lstmvm.Add(new AttendanceViewModel() { Status = item.Status, AttendanceDate = item.AttendanceDate });
            }
            return View(lstmvm);
        }
        public ActionResult ViewProfile()
        {
            UserViewModel uvm = new UserViewModel();
            int userid =Convert.ToInt32( Session["userid"].ToString());
            tblUser tbu = _db.tblUsers.Where(u => u.UserId == userid).FirstOrDefault();
            uvm.UserId = tbu.UserId;
            uvm.Fullname = tbu.Fullname;
            uvm.Email = tbu.Email;
            
            HttpPostedFileBase fup = Request.Files["Photo"];
            if (fup != null)
            {
                tbu.Photo = fup.FileName;
                fup.SaveAs(Server.MapPath("~/MemberPhoto/" + fup.FileName));
            }
            else
            {
                uvm.Photo = tbu.Photo;
            }

            uvm.Phone = tbu.Phone;
            uvm.Gender = tbu.Gender;






            return View(uvm);
        }
       [ValidateOnlyIncomingValues]
        [HttpPost]
        public ActionResult ViewProfile(UserViewModel tbu)
        {

            int userid = Convert.ToInt32(Session["userid"].ToString());
            tblUser uvm = _db.tblUsers.Where(u => u.UserId == tbu.UserId).FirstOrDefault();
            
            uvm.Fullname = tbu.Fullname;
            uvm.Email = tbu.Email;

            HttpPostedFileBase fup = Request.Files["Photo"];
            if (fup != null)
            {
                tbu.Photo = fup.FileName;
                fup.SaveAs(Server.MapPath("~/MemberPhoto/" + fup.FileName));
            }
            else
            {
                uvm.Photo = tbu.Photo;
            }

            uvm.Phone = tbu.Phone;
            uvm.Gender = tbu.Gender;






            return View(uvm);
        }
        public ActionResult ChangePassword()
        {



            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            int userid = Convert.ToInt32(Session["userid"].ToString());

            tblUser us = _db.tblUsers.Where(u => u.UserId == userid && u.Password == ch.OldPassword).FirstOrDefault();
            if (us != null)
            {
                us.Password = ch.NewPassword;
                _db.SaveChanges();
                ViewBag.Message = "Password Changed Successfully";
            }
            else
            {
                ViewBag.Message = "Wrong Old Password";
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult ViewWorkout()
        {
             int userid=Convert.ToInt32( Session["userid"].ToString());
            tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == userid).FirstOrDefault();

            List<WorkoutViewModel> lstworkout = new List<WorkoutViewModel>();

            var works = _db.tblWorkouts.OrderByDescending(u => u.WorkoutId).Where(m => m.MemberId == tbm.MembershipId).Take(6);
           
            foreach (var item in works)
            {
                lstworkout.Add(new WorkoutViewModel() { MemberId = item.MemberId, WorkoutDays = item.WorkoutDays, Description = item.Description });
            }
            return View(lstworkout);
        }




    }
}
