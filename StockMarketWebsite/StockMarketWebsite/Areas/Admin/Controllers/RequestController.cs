using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketWebsite.Areas.Admin.Controllers
{
    public class RequestController : Controller
    {
        StockMarketDbContext ctx;
        public RequestController( StockMarketDbContext context)
        {
            
            ctx = context;
        }
        public IActionResult Index(TbRequest element)
        {
            ctx.TbRequests.Add(element);

            return View();
        }
    }
}
