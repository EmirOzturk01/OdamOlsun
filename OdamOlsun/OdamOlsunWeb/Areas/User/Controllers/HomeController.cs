using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.Entities.Models.Concrete;
using OdamOlsunWeb.Models.ViewModels;
using OdamOlsun.Utilities;

namespace OdamOlsunWeb.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIlanManager _ilanManager;
        private readonly IResimManager _resimManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;



        public HomeController(ILogger<HomeController> logger, IIlanManager ilanManager, IResimManager resimManager, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _ilanManager = ilanManager;
            _resimManager = resimManager;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Ilan> latestIlans = await _ilanManager.GetAllInclude(u => u.Resims)
                            .OrderByDescending(u => u.CreateDate)
                            .Take(4).ToListAsync();
            foreach (var ilan in latestIlans)
            {
                CityService cityService = new CityService();
                ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));
            }
            return View(latestIlans);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(Error);
        }

        public async Task<IActionResult> Details(int id)
        {
            Ilan ilan = await _ilanManager.GetAllInclude(u => u.Resims).Include(u=> u.ApplicationUser).FirstOrDefaultAsync(u => u.Id == id);


            if (ilan == null)
            {
                return NotFound();
            }
            CityService cityService = new CityService();
            ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));

            return View(ilan);
        }
    }
}