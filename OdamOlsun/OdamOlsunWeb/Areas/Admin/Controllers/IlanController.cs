using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.BL.Managers.Concrete;
using OdamOlsun.Entities.Models.Concrete;
using OdamOlsun.Utilities;
using OdamOlsunWeb.Models.ViewModels;
using X.PagedList.Mvc.Core;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
namespace OdamOlsunWeb.Controllers
{
    [Area("Admin")]
    // Eğer authorize kısmını action ın üstüne yazarsan sadece ilgili aksiyonu kısıtlar
    [Authorize(Roles = SD.Role_Admin)]
    public class IlanController : Controller
    {
        private readonly IIlanManager _ilanManager;
        private readonly IResimManager _resimManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public IlanController(IIlanManager ilanManager, IResimManager resimManager, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _ilanManager = ilanManager;
            _resimManager = resimManager;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index(int? page)
        {
            var ilanlar = await _ilanManager.GetAll().ToList().ToPagedListAsync(page ?? 1, 10);
            return View(ilanlar);
        }

        public async Task<IActionResult> Create()
        {
            IlanVM ilanVM = new IlanVM();
            return View(ilanVM);
        }

        [HttpPost]
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
                            await formFile.CopyToAsync(fileStream);
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
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            Ilan obj = _ilanManager.GetAllInclude(u => u.Resims).FirstOrDefault(u => u.Id == id);

            if (obj != null)
            {
                _ilanManager.DeleteAsync(obj);
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


                return RedirectToAction("Index");
            }
            return View();
        }
    }
}