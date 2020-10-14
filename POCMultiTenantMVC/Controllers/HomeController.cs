using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POCMultiTenantMVC.Middlewares;
using POCMultiTenantMVC.Models;

namespace POCMultiTenantMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITenantProvider _tenantProvider;

        public HomeController(ILogger<HomeController> logger, ITenantProvider tenantProvider)
        {                        
            _logger = logger;
            _tenantProvider = tenantProvider;
        }

        public IActionResult Index()
        {            
            return View(_tenantProvider.GetTenant());
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
