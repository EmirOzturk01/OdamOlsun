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
using Microsoft.AspNetCore.Authorization;




namespace OdamOlsunWeb.Areas.User.Controllers
{
    [Area("User")]
    public class IlanlarController : Controller
    {
        private readonly ILogger<IlanlarController> _logger;

        private readonly IIlanManager _ilanManager;
        private readonly IResimManager _resimManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public IlanlarController(ILogger<IlanlarController> logger, UserManager<ApplicationUser> userManager, IIlanManager ilanManager, IResimManager resimManager, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _userManager = userManager;
            _ilanManager = ilanManager;
            _resimManager = resimManager;
            _webHostEnvironment = webHostEnvironment;

        }
        
        [HttpGet]
        [Authorize(Roles = SD.Role_Customer + "," + SD.Role_Admin)]

        public async Task<IActionResult> Index()
        {
            var userId =  _userManager.GetUserId(User);
            IEnumerable<Ilan> ilanlar =await _ilanManager.GetAllInclude(u => u.Resims).Include(u => u.ApplicationUser).Where(i => i.ApplicationUserId == userId).ToListAsync();
            if (ilanlar.Any())
            {
                foreach (var ilan in ilanlar)
                {
                    CityService cityService = new CityService();
                    ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));
                }
                return View(ilanlar);
            }
            return View();
        }

        // [HttpGet]
        // [Authorize(Roles = SD.Role_Customer)]
        // public IActionResult Index(string userId)
        // {
        //     IEnumerable<Ilan> ilanlar = _ilanManager.GetAllInclude(u => u.Resims).Include(u => u.ApplicationUser).Where(i => i.ApplicationUserId == userId).ToList();
        //     if (ilanlar.Any())
        //     {
        //         foreach (var ilan in ilanlar)
        //         {
        //             CityService cityService = new CityService();
        //             ilan.Il = cityService.GetIl(Convert.ToInt32(ilan.Il));
        //         }
        //         return View(ilanlar);
        //     }
        //     return View();
        // }


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

        [Authorize(Roles = SD.Role_Customer)]
        public async Task<IActionResult> Delete(int id)
        {
            Ilan obj = await _ilanManager.GetAllInclude(u => u.Resims).FirstOrDefaultAsync(u => u.Id == id);

            if (obj != null)
            {
                await _ilanManager.DeleteAsync(obj);
                if (obj.Resims != null)
                {
                    foreach (var resim in obj.Resims)
                    {
                        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, resim.Url.TrimStart('/'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                }
                TempData["success"] = "İlan Başarıyla Silindi";
            }
            return RedirectToAction("Index");
        }

                [Authorize(Roles = SD.Role_Customer + "," + SD.Role_Admin)]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Ilan? ilan = await _ilanManager.GetAllInclude(p => p.Resims).FirstOrDefaultAsync(u => u.Id == id);

            if (ilan == null)
            {
                return NotFound();
            }
            IlanVM ilanVM = new IlanVM
            {
                Title = ilan.Title,
                Size = ilan.Size,
                Price = ilan.Price,
                Deposit = ilan.Deposit,
                Address = ilan.Address,
                NumberOfRooms = ilan.NumberOfRooms,
                NumberOfFloorOfBuild = ilan.NumberOfFloorOfBuild,
                FloorOfHouse = ilan.FloorOfHouse,
                AgeOfBuild = ilan.AgeOfBuild,
                Furnished = ilan.Furnished,
                Cigarette = ilan.Cigarette,
                Animal = ilan.Animal,
                RoomAndHomeDetails = ilan.RoomAndHomeDetails,
                Il = ilan.Il,
                Ilce = ilan.Ilce,
                Semt = ilan.Semt
            };

            return View(ilanVM);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Customer)]

        public async Task<IActionResult> Edit(IlanVM obj)
        {
            if (ModelState.IsValid)
            {
                Ilan ilan = await _ilanManager.GetByIdAsync(obj.Id);

                if (ilan == null)
                {
                    return NotFound();
                }

                ilan.Title = obj.Title;
                ilan.Size = obj.Size;
                ilan.Price = obj.Price;
                ilan.Deposit = obj.Deposit;
                ilan.Address = obj.Address;
                ilan.NumberOfRooms = obj.NumberOfRooms;
                ilan.NumberOfFloorOfBuild = obj.NumberOfFloorOfBuild;
                ilan.FloorOfHouse = obj.FloorOfHouse;
                ilan.AgeOfBuild = obj.AgeOfBuild;
                ilan.Furnished = obj.Furnished;
                ilan.Cigarette = obj.Cigarette;
                ilan.Animal = obj.Animal;
                ilan.RoomAndHomeDetails = obj.RoomAndHomeDetails;
                ilan.Il = obj.Il;
                ilan.Ilce = obj.Ilce;
                ilan.Semt = obj.Semt;

                await _ilanManager.UpdateAsync(ilan);
                TempData["success"] = "İlan Başarıyla Güncellendi";

                string userId = _userManager.GetUserId(User); // Dinamik olarak alınıyor.
                string url = $"/User/Ilanlar?userId={userId}";

                return Redirect(url);
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Customer)]

        public IActionResult Create()
        {
            IlanVM ilanVM = new IlanVM();
            return View(ilanVM);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Customer)]

        public async Task<IActionResult> Create(IlanVM obj, List<IFormFile> Resims)
        {
            if (ModelState.IsValid)
            {   //ilanı veritabanına kaydetme!
                var userId = _userManager.GetUserId(User);

                Ilan ilan = new Ilan()
                {
                    Id = obj.Id,
                    Title = obj.Title,
                    Size = obj.Size,
                    Price = obj.Price,
                    Deposit = obj.Deposit,
                    Address = obj.Address,
                    NumberOfRooms = obj.NumberOfRooms,
                    NumberOfFloorOfBuild = obj.NumberOfFloorOfBuild,
                    FloorOfHouse = obj.FloorOfHouse,
                    AgeOfBuild = obj.AgeOfBuild,
                    Furnished = obj.Furnished,
                    Cigarette = obj.Cigarette,
                    Animal = obj.Animal,
                    RoomAndHomeDetails = obj.RoomAndHomeDetails,
                    Il = obj.Il,
                    Ilce = obj.Ilce,
                    Semt = obj.Semt,
                    ApplicationUserId = userId

                };
                await _ilanManager.InsertAsync(ilan);

                //resimleri kaydetme
                if (Resims != null && Resims.Count > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    foreach (var formFile in Resims)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"images/ilan");
                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            formFile.CopyTo(fileStream);
                        }
                        var resim = new Resim
                        {
                            Url = @"/images/ilan/" + fileName, //"/uploads/" + formFile.FileName,
                            IlanId = ilan.Id
                        };
                        await _resimManager.InsertAsync(resim);
                    }
                }


                TempData["success"] = "İlan Başarıyla Oluşturuldu";
                // Dinamik olarak alınıyor.
                string url = $"/User/Ilanlar?userId={userId}";
                return Redirect(url);
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}