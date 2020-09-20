using GymManagement.Models;
using GymManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GymManagement.Controllers
{
    
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        GymDBEntities _db = new GymDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();

            //return RedirectToAction("Index", "Home");
        }
        public ActionResult ForgetPassword()
        {
            return View();

            //return RedirectToAction("Index", "Home");
        }
        [ValidateOnlyIncomingValuesAttribute]
        [HttpPost]

        public ActionResult ForgetPassword(UserViewModel uv)
        {

            if (ModelState.IsValid)
            {
                //https://www.google.com/settings/security/lesssecureapps
                //Make Access for less secure apps=true

                string from = "gfccafe123@gmail.com";
                using (MailMessage mail = new MailMessage(from,uv.Email))
                {
                    try
                    {
                        tblUser tb = _db.tblUsers.Where(u => u.Email == uv.Email).FirstOrDefault();
                        if (tb != null)
                        {
                            mail.Subject = "Password Recovery";
                            mail.Body = "Your Password is:" + tb.Password;

                            mail.IsBodyHtml = false;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential networkCredential = new NetworkCredential(from, "suneel!@#123");
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = networkCredential;
                            smtp.Port = 587;
                            smtp.Send(mail);
                            ViewBag.Message = "Your Password Is Sent to your email";
                        }
                        else
                        {
                            ViewBag.Message = "email Doesnot Exist in Database";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        
                    }
                   
                }

            }
            return View();
           

            //return RedirectToAction("Index", "Home");
        }
        [HttpPost]

        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                using (GymDBEntities db = new GymDBEntities())
                {
                    var users = db.tblUsers.Where(a => a.Username == l.Username && a.Password == l.Password).FirstOrDefault();
                    if (users != null)
                    {
                        Session.Add("emailid", users.Email);
                        Session.Add("userid", users.UserId);
                        Session.Add("fullname", users.Fullname);
                        Session.Add("photo", users.Photo);
                        FormsAuthentication.SetAuthCookie(l.Username, true);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {

                            tblUser tb = db.tblUsers.Where(u => u.Username == l.Username && u.Password == l.Password).FirstOrDefault();

                            MyRoleProvider mp = new MyRoleProvider();
                            if (mp.IsUserInRole(l.Username, "User") == true)
                            {

                                //if (User.IsInRole("Teacher"))
                                //{
                                return RedirectToAction("Index", "User");
                            }
                            else if (mp.IsUserInRole(l.Username, "Admin") == true)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Invalid user";
                    }
                }
            }
           
            return View();

        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }


    }
}
