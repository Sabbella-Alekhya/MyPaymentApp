using Microsoft.AspNetCore.Mvc;
using MyPaymentApp.Models;
using System;

namespace MyPaymentApp.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PaymentModel());
        }

        [HttpPost]
        public IActionResult Index(PaymentModel model)
        {
            if (string.IsNullOrEmpty(model.UpiId) && string.IsNullOrEmpty(model.PhoneNumber))
            {
                ModelState.AddModelError("", "Enter either UPI ID or Phone Number.");
                return View(model);
            }

            model.TransactionId = "TXN" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            model.Status = (model.Amount >= 1 && model.Amount <= 50000) ? "Success" : "Failed";

            TempData["Result"] = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            var json = TempData["Result"] as string;
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentModel>(json);
            return View(result);
        }
    }
}
