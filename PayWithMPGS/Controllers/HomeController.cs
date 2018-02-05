using PayWithMPGS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayWithMPGS.Services;

namespace PayWithMPGS.Controllers
{
    public class HomeController : Controller
    {
        private readonly MPGSContext context;
        private readonly PaymentService payment;
        public HomeController()
        {
            context = new MPGSContext();
            payment = new PaymentService();
        }

        public ActionResult Index()
        {
            var model = new MPGSPayment();
            model.Name = "SomeName";
            model.Email = "email@example.com";
            model.Phone = "7777777777";
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MPGSPayment model)
        {
            if(ModelState.IsValid)
            {
                model.ClientIP = Request.UserHostAddress;
                model.TimeStampInitiated = DateTime.Now;
                model.OrderId = DateTime.Now.ToString("MMyyyyMMddhhmmss");
                context.MPGSPayments.Add(model);
                context.SaveChanges();
                bool paymentResponse = payment.PayWithPaymentGateway(model,Request.Form["inputNoStore"].ToString());
                if(paymentResponse)
                {
                    
                    model.Paid = true;
                    model.CheckSum = "";
                    model.TimeStampSuccess = DateTime.Now;
                    context.SaveChanges();
                    return Redirect("Reciept?Id=" + model.OrderId);
                }
                return RedirectToAction("Failed");
            }
            return View(model);
        }

        public ActionResult Reciept(string Id)
        {
            var model = context.MPGSPayments.Where(m => m.OrderId == Id).FirstOrDefault();
            return View(model);
        }

        public ActionResult Failed()
        {            
            return View();
        }
    }
}