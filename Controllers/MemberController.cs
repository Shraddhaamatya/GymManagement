using GymManagement.Models;
using GymManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GymManagement.Controllers
{
   [Authorize]
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        GymDBEntities _db = new GymDBEntities();
        public ActionResult Index()
        {
            List<MemberViewModel> memvlst = new List<MemberViewModel>();
            var mem = _db.tblMemberships.ToList();
            foreach (var item in mem)
            {
                tblUser tb = _db.tblUsers.Where(u => u.UserId == item.UserId).FirstOrDefault();
                memvlst.Add(new MemberViewModel() {MemberId=item.MembershipId, Fullname=tb.Fullname,Email=tb.Email,Photo=tb.Photo,Phone=tb.Phone,Fees=item.Fees });
            }
            return View(memvlst);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPricebyMembershiptypeId(int membershiptypeId)
        {
           

            var states = _db.tblMembershipTypes.Where(m => m.MembershipTypeId == membershiptypeId).FirstOrDefault();
            var price = states.Price;
            return Json(price, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetMemberTotalPaymentAmount(int memberid)
        {
            tblMembership tbmem = _db.tblMemberships.Where(m => m.MembershipId == memberid).FirstOrDefault();
            int? membershiptypeid = tbmem.MembershipTypeId;
            tblMembershipType tbmtype = _db.tblMembershipTypes.Where(mem => mem.MembershipTypeId==membershiptypeid).FirstOrDefault();
            //int? month = tbmtype.AllowedMonth;
            //int? totaldays = month * 30;

            //SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=GymDB");
            //SqlCommand cmd = new SqlCommand("select Sum(PaidAmount) as TotalAmount from tblPayment where PaymentDate>=(Getdate()-"+totaldays+") group by MemberId", con);

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //var totalamount = dt.Rows[0][0].ToString();
            //var states = _db.tblPayments.Where(m => m.MemberId == memberid).FirstOrDefault();
            var price = tbmtype.Price;
            return Json(price, JsonRequestBehavior.AllowGet);
        } 
        public ActionResult Create()
        {
            MemberViewModel vm = new MemberViewModel();
            string regdate = DateTime.Now.ToString("MM/dd/yyyy");
            vm.RegDate = Convert.ToDateTime(regdate);



            ViewBag.Role = _db.Roles.ToList();

            ViewBag.Shift = _db.tblShifts.ToList();

            ViewBag.MembershipType = _db.tblMembershipTypes.ToList();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(MemberViewModel mem)
        {
            tblUser checkuser = _db.tblUsers.Where(u => u.Username == mem.Username).FirstOrDefault();
            if (checkuser != null)
            {
                ViewBag.Message = "Username Already Taken";
            }
            else
            {
                tblUser checkEmail = _db.tblUsers.Where(u => u.Email == mem.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    ViewBag.Message = "Email Already Taken";
                }
                else
                {
                    tblUser tb = new tblUser();
                    tb.Fullname = mem.Fullname;
                    tb.Email = mem.Email;
                    tb.Phone = mem.Phone;

                    HttpPostedFileBase fup = Request.Files["Photo"];
                    if (fup != null)
                    {
                        tb.Photo = fup.FileName;
                        fup.SaveAs(Server.MapPath("~/MemberPhoto/" + fup.FileName));
                    }
                    tb.Gender = mem.Gender;
                    tb.Username = mem.Username;
                    tb.Password = mem.Password;

                    _db.tblUsers.Add(tb);
                    _db.SaveChanges();

                    tblMembership tbm = new tblMembership();
                    tbm.UserId = tb.UserId;
                    tbm.MembershipTypeId = mem.MembershipTypeId;
                    tbm.RegDate = mem.RegDate;
                    tbm.Fees = mem.Price;
                    tbm.ShiftId = mem.ShiftId;




                    _db.tblMemberships.Add(tbm);
                    _db.SaveChanges();

                    UserRole ur = new UserRole();
                    ur.RoleId = mem.RoleId;
                    ur.UserId = tb.UserId;
                    _db.UserRoles.Add(ur);
                    _db.SaveChanges();

                    tblPayment pay = new tblPayment();
                    pay.MemberId = tbm.MembershipId;
                    pay.PaidAmount = mem.Price;
                    pay.RemainingAmount = 0.0M;
                    pay.PaymentDate = DateTime.Today;
                    _db.tblPayments.Add(pay);
                    _db.SaveChanges();
                    ViewBag.Message = "Member Added";
                }




               
            }



            string regdate = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.Role = _db.Roles.ToList();

            ViewBag.Shift = _db.tblShifts.ToList();

            ViewBag.MembershipType = _db.tblMembershipTypes.ToList();
           
            return View(mem);
        }
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tblMembership tblMemberships = _db.tblMemberships.Find(id);
			if (tblMemberships == null)
			{
				return HttpNotFound();
			}
			return View(tblMemberships);

		}

		public ActionResult Edit(int id)
        {
           

            MemberViewModel vm = new MemberViewModel();

            tblMembership tb = _db.tblMemberships.Where(m => m.MembershipId == id).FirstOrDefault();
            tblUser tbu = _db.tblUsers.Where(u => u.UserId == tb.UserId).FirstOrDefault();
            
            vm.MemberId = tb.MembershipId;
            vm.UserId = tbu.UserId; ;
            vm.Fullname = tbu.Fullname;
            vm.Email = tbu.Email;
            vm.Photo = tbu.Photo;
            vm.Phone = tbu.Phone;
            vm.Gender = tbu.Gender;
            vm.MembershipTypeId = tb.MembershipId;
            vm.Fees = tb.Fees;
            vm.RegDate = tb.RegDate;
            vm.ShiftId = tb.ShiftId;

            string regdate = DateTime.Now.ToString("MM/dd/yyyy");
            vm.RegDate = Convert.ToDateTime(regdate);



            ViewBag.Role = _db.Roles.ToList();

            ViewBag.Shift = _db.tblShifts.ToList();

            ViewBag.MembershipType = _db.tblMembershipTypes.ToList();
            return View(vm);
        }
      
        [HttpPost]
        [ValidateOnlyIncomingValues]
        public ActionResult Edit(MemberViewModel memvm)
        {
            if (ModelState.IsValid)
            {

                tblMembership tb = _db.tblMemberships.Where(m => m.MembershipId == memvm.MemberId).FirstOrDefault();
                tblUser tbu = _db.tblUsers.Where(u => u.UserId == memvm.UserId).FirstOrDefault();

                tbu.Fullname = memvm.Fullname;
                tbu.Email = memvm.Email;
                HttpPostedFileBase fup = Request.Files["Photo"];
                if (fup != null && fup.FileName != "")
                {
                    tbu.Photo = fup.FileName;
                    fup.SaveAs(Server.MapPath("~/MemberPhoto/" + fup.FileName));
                }
                else
                {
                    tbu.Photo = memvm.Photo;
                }

                tbu.Phone = memvm.Phone;
                tbu.Gender = memvm.Gender;
                tb.MembershipTypeId = memvm.MemberId;
                tb.Fees = memvm.Fees;
                tb.RegDate = memvm.RegDate;
                tb.ShiftId = memvm.ShiftId;

                string regdate = DateTime.Now.ToString("MM/dd/yyyy");
                tb.RegDate = Convert.ToDateTime(regdate);
                _db.SaveChanges();


               
                ViewBag.Message = "Member Updated";
            }
            ViewBag.Role = _db.Roles.ToList();

            ViewBag.Shift = _db.tblShifts.ToList();

            ViewBag.MembershipType = _db.tblMembershipTypes.ToList();
            return View(memvm);
        }
        public ActionResult DeleteMember(int id)
        {


            MemberViewModel vm = new MemberViewModel();

            tblMembership tb = _db.tblMemberships.Where(m => m.MembershipId == id).FirstOrDefault();
            tblUser tbu = _db.tblUsers.Where(u => u.UserId == tb.UserId).FirstOrDefault();

            vm.MemberId = tb.MembershipId;
            vm.UserId = tbu.UserId; ;
            vm.Fullname = tbu.Fullname;
            vm.Email = tbu.Email;
            vm.Photo = tbu.Photo;
            vm.Phone = tbu.Phone;
            vm.Gender = tbu.Gender;
            vm.MembershipTypeId = tb.MembershipId;
            vm.Fees = tb.Fees;
            vm.RegDate = tb.RegDate;
            vm.ShiftId = tb.ShiftId;

            string regdate = DateTime.Now.ToString("MM/dd/yyyy");
            vm.RegDate = Convert.ToDateTime(regdate);



            ViewBag.Role = _db.Roles.ToList();

            ViewBag.Shift = _db.tblShifts.ToList();

            ViewBag.MembershipType = _db.tblMembershipTypes.ToList();
            return View(vm);
        }
       [HttpPost,ActionName("DeleteMember")]
        public ActionResult DeleteMember_Post(int id)
        {


            MemberViewModel vm = new MemberViewModel();

            tblMembership tb = _db.tblMemberships.Where(m => m.MembershipId == id).FirstOrDefault();
            _db.tblMemberships.Remove(tb);
            _db.SaveChanges();
            return RedirectToAction("Index", "Member");
            
        }
        public ActionResult Payment()
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
            PaymentViewModel pm = new PaymentViewModel();
           
           pm.PaymentDate =DateTime.Today;
            return View(pm);
        }
        [HttpPost]
        public ActionResult Payment(PaymentViewModel pvm)
        {
            tblPayment tb = new tblPayment();
            tb.MemberId = pvm.MemberId;
            tb.PaidAmount = pvm.PaidAmount;
            tb.PaymentDate = pvm.PaymentDate;
            _db.tblPayments.Add(tb);
            _db.SaveChanges();
            ViewBag.Message = "Payment Done Successfully";

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
            return View();
        }
        public ActionResult MessageSender()
        {
            List<UserViewModel> lstu = new List<UserViewModel>();
            var users = _db.tblUsers.Where(u=>u.Usertype=="User").ToList();
            foreach (var item in users)
            {
                lstu.Add(new UserViewModel() { Fullname = item.Fullname, Email = item.Email });
            }
            ViewBag.list = lstu;
            return View();
        }
        [HttpPost]
        public ActionResult MessageSender(MailViewModel mvm)
        {
            // Modify this to suit your business case:
            string mailUser = "gfccafe123@gmail.com";
            string mailUserPwd = "suneel!@#123";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(mailUser, mailUserPwd);
            client.EnableSsl = true;
            client.Credentials = credentials;


           
            var users = _db.tblUsers.ToList();


            foreach (var msg in users)
            {
                var mail = new MailMessage(mailUser, msg.Email.Trim());
                mail.Subject = mvm.Subject;
                mail.Body = mvm.Message;

                try
                {
                    client.Send(mail);
                    //return RedirectToAction("SuccessfullMessage", "Member");
                    
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                    // Or, more likely, do some logging or something
                }
            }

            List<UserViewModel> lstu = new List<UserViewModel>();
            var userss = _db.tblUsers.ToList();
            foreach (var item in userss)
            {
                lstu.Add(new UserViewModel() { Fullname = item.Fullname, Email = item.Email });
            }
            ViewBag.list = lstu;
            ViewBag.Message = "Mail Send";
            
            return View();
        }
        public ActionResult SuccessfullMessage()
        {
            ViewBag.Message = "Message Sent Successfully";
            return View();
        }
        

    }
}
