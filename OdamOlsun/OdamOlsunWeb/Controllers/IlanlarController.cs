using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.Entities.Models.Concrete;
using OdamOlsun.Utilities;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace OdamOlsunWeb.Controllers
{
    [Route("Ilanlar")]
    public class IlanlarController : Controller
    {
        private readonly ILogger<IlanlarController> _logger;
        private readonly IIlanManager _ilanManager;
        private readonly IResimManager _resimManager;

        public IlanlarController(ILogger<IlanlarController> logger, IIlanManager ilanManager, IResimManager resimManager)
        {
            _logger = logger;
            _resimManager = resimManager;
            _ilanManager = ilanManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int? page, int? il, string? ilce, string? semt)
        {
            //---------------------------------------------------------//
            IQueryable<Ilan> ilanlar = _ilanManager.GetAllInclude(u => u.Resims).Include(u => u.ApplicationUser); ;
            
            if (il.HasValue)
            {
                ilanlar = ilanlar.Where(i => i.Il == il.Value.ToString());
            }
            if (!string.IsNullOrEmpty(ilce))
            {
                ilanlar = ilanlar.Where(i => i.Ilce == ilce);
            }
            if (!string.IsNullOrEmpty(semt))
            {
                ilanlar = ilanlar.Where(i => i.Semt == semt);
            }
            ViewBag.TotalIlans = ilanlar.Count();   

            var pagedList = await ilanlar.OrderByDescending(u => u.CreateDate).ToList().ToPagedListAsync(page ?? 1, 5);

            if (pagedList.Any())
            {
                foreach (var ilan in pagedList)
                {
                    CityService cityService = new CityService();
                    ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));
                }
            }
            return View(pagedList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Ilan ilan = await _ilanManager.GetAllInclude(u => u.Resims).Include(u => u.ApplicationUser).FirstOrDefaultAsync(u => u.Id == id);


            if (ilan == null)
            {
                return NotFound();
            }
            CityService cityService = new CityService();
            ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));

            return View(ilan);
        }

        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}