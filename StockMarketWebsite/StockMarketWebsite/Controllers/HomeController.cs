using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarketWebsite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using BL;
using EmailService;
using Microsoft.AspNetCore.Http;

namespace StockMarketWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StockMarketDbContext ctx;
        IEmailSender _emailSender;
        public HomeController(IEmailSender emailSender, ILogger<HomeController> logger , StockMarketDbContext context)
        {
            _logger = logger;
            ctx = context;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Form1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(TbRequest element , string SubscriptionFee , string SubscriptionType, string SubscriptionPeriod , string TotalProfit , string CreatedBy)
        {
            element.SubscriptionFee = int.Parse(SubscriptionFee);
            element.TotalProfit = int.Parse(TotalProfit);
            element.DateOfRequest = DateTime.Now;
            if (SubscriptionType == "0") 
            {
                element.SubscriptionType = "TRIAL";

            }
            else
            {
                element.SubscriptionType = "PRO";

            }
            if (SubscriptionPeriod == "0")
            {
                element.SubscriptionPeriod = "24 HOURS";

            }
            else if(SubscriptionPeriod == "1")
            {
                element.SubscriptionPeriod = "WEEKLY";

            }
            else
            {
                element.SubscriptionPeriod = "MONTHLY";
            }
            if(CreatedBy == "true")
            {
                element.PdfFee = 1;
            }
            else
            {
                element.PdfFee = 0;
            }


            return RedirectToAction("BIANCE", element);
           
        }


        public IActionResult BIANCE(TbRequest element)
        {


            return View();
        }
        public IActionResult BIANCE2(TbRequest element)
        {


            return View();
        }

        //public IActionResult saveToDatabase(TbRequest element)
        //{
        //    ctx.TbRequests.Add(element);
        //    ctx.SaveChanges();
        //    return View();

        //}
        public async Task<IActionResult> saveToDatabase(TbRequest element, IFormFileCollection files)
        {
          
            try
            {
                
                    var userEmail = element.Email;

                    //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
                    var messages = new Message(new string[] { "support@collectsignals.com" }, "Email From Customer " + "His name is " + element.UserName + "\n" + " His Email Is " + element.Email + "\n", "This is the content from our async email. i am happy" , files , "");
                var messages2 = new Message(new string[] { element.Email }, "Email From Customer " + "His name is " + element.UserName + "\n" + " His Email Is " + element.Email + "\n", "This is the content from our async email. i am happy", files, "");
                //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
                ctx.TbRequests.Add(element);
                ctx.SaveChanges();
                await _emailSender.SendEmailAsync2(messages, element.SubscriptionType , "" , element);
                await _emailSender.SendEmailAsync3(messages2, element.SubscriptionType, "", element);
                //_notyf.Success("The Message Has Been Sent");

                return View(element);
               

            }
            catch (Exception ex)
            {
                ViewBag.ex = ex;
                return View(element);

            }


        }





        public async Task<IActionResult> saveToDatabase1(TbRequest element, IFormFileCollection files)
        {

            try
            {

                var userEmail = element.Email;

                //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
                var messages = new Message(new string[] { "support@collectsignals.com" }, "Email From Customer " + "His name is " + element.UserName + "\n" + " His Email Is " + element.Email + "\n", "This is the content from our async email. i am happy", files, "");
                var messages2 = new Message(new string[] { element.Email }, "Email From Customer " + "His name is " + element.UserName + "\n" + " His Email Is " + element.Email + "\n", "This is the content from our async email. i am happy", files, "");
                //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
                ctx.TbRequests.Add(element);
                ctx.SaveChanges();
                await _emailSender.SendEmailAsync2(messages, element.SubscriptionType, "", element);
                await _emailSender.SendEmailAsync3(messages2, element.SubscriptionType, "", element);
                //_notyf.Success("The Message Has Been Sent");

                return View(element);


            }
            catch (Exception ex)
            {
                ViewBag.ex = ex;
                return View(element);

            }


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
