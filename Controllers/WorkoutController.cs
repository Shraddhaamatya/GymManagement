using GymManagement.Models;
using GymManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymManagement.Controllers
{
    public class WorkoutController : Controller
    {
        //
        // GET: /Workout/

        GymDBEntities _db = new GymDBEntities();
        public ActionResult Index()
        {
            List<MemberViewModel> memvlst = new List<MemberViewModel>();
            var mem = _db.tblMemberships.ToList();
            foreach (var item in mem)
            {
                tblUser tb = _db.tblUsers.Where(u => u.UserId == item.UserId).FirstOrDefault();
                memvlst.Add(new MemberViewModel() { MemberId = item.MembershipId, Fullname = tb.Fullname, Email = tb.Email, Photo = tb.Photo, Phone = tb.Phone, Fees = item.Fees });
            }
            return View(memvlst);
        }
        public ActionResult Add()
        {
            List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

            var users = _db.tblUsers.Where(u=>u.Usertype=="User").ToList();
            foreach (var item in users)
            {
                tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                if (tbm != null)
                {
                    lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                }
            }
           

            
            ViewBag.Fullname = lstmemvm;
            return View();
        }
        [HttpPost]
        public ActionResult Add(int MemberId,string SunDesc, string MonDesc, string TueDesc, string WedDesc, string ThuDesc, string FriDesc)
        {

            if (ModelState.IsValid)
            {
                int? memberid = MemberId;

                tblWorkout tb = new tblWorkout();
                tb.MemberId = memberid;
                tb.WorkoutDays = "Sunday";
                tb.Description = SunDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();

                tb.WorkoutDays = "Monday";
                tb.Description = MonDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();


                tb.WorkoutDays = "Tuesday";
                tb.Description = TueDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();

                tb.WorkoutDays = "Wednesday";
                tb.Description = WedDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();

                tb.WorkoutDays = "Thursday";
                tb.Description = ThuDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();

                tb.WorkoutDays = "Friday";
                tb.Description = FriDesc;
                _db.tblWorkouts.Add(tb);
                _db.SaveChanges();
            }






            List<MemberViewModel> lstmemvm = new List<MemberViewModel>();

            var users = _db.tblUsers.ToList();
            foreach (var item in users)
            {
                tblMembership tbm = _db.tblMemberships.Where(m => m.UserId == item.UserId).FirstOrDefault();
                if (tbm != null)
                {
                    lstmemvm.Add(new MemberViewModel() { MemberId = tbm.MembershipId, Fullname = item.Fullname });
                }

            }



            ViewBag.Fullname = lstmemvm;
            ViewBag.Message = "Work out Added Successfully";
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            List<WorkoutViewModel> lstwork = new List<WorkoutViewModel>();
            var workouts = _db.tblWorkouts.Where(m => m.MemberId == id).ToList();
            foreach (var item in workouts)
            {
                lstwork.Add(new WorkoutViewModel() { MemberId = item.MemberId, WorkoutDays = item.WorkoutDays, Description = item.Description });
            }
            return View(lstwork);
        }
        public ActionResult Delete()
        {
            return View();
        }

    }
}
