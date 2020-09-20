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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        GymDBEntities _db = new GymDBEntities();
        public ActionResult ViewProfile()
        {
            UserViewModel uvm = new UserViewModel();
            int userid = Convert.ToInt32(Session["userid"].ToString());
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
            if (ModelState.IsValid)
            {
            tblUser uvm = _db.tblUsers.Where(u => u.UserId == tbu.UserId).FirstOrDefault();
          
            HttpPostedFileBase fup = Request.Files["Photo"];
            if (fup != null)
            {
                if (fup.FileName == "")
                {
                    uvm.Photo = tbu.Photo;
                }
                else
                {
                    uvm.Photo = fup.FileName;
                    fup.SaveAs(Server.MapPath("~/MemberPhoto/" + fup.FileName));
                }
            }

          

                int userid = Convert.ToInt32(Session["userid"].ToString());
               

                uvm.Fullname = tbu.Fullname;
                uvm.Email = tbu.Email;

               

                uvm.Phone = tbu.Phone;
                uvm.Gender = tbu.Gender;

                _db.SaveChanges();

                ViewBag.Message = "Profile Updated Successfully";

            }


            return View(tbu);
        }
        public ActionResult ChangePassword()
        {
           


            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            int userid=Convert.ToInt32(Session["userid"].ToString());

            tblUser us = _db.tblUsers.Where(u => u.UserId == userid && u.Password==ch.OldPassword).FirstOrDefault();
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

    }
}
