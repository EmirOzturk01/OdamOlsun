// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using OdamOlsun.Entities.Models.Concrete;



namespace OdamOlsunWeb.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Required(ErrorMessage = "You can not delete your phone Number.")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "You can not delete your Name.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "You can not delete your Surname.")]
            public string Surname { get; set; }
            public string? SocialInstagram { get; set; }

            public string? SocialSnapchat { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var name = user.Name;
            var surname = user.Surname;
            var phoneNumber = user.PhoneNumber;
            var instagram = user.SocialInstagram;
            var snapchat = user.SocialSnapchat;


            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Name = name,
                Surname = surname,
                SocialInstagram = instagram,
                SocialSnapchat = snapchat,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //modelden scope atama

            var name = user.Name;
            var surname = user.Surname;
            var phoneNumber = user.PhoneNumber;
            var instagram = user.SocialInstagram;
            var snapchat = user.SocialSnapchat;

            //phone güncelleme
            if (Input.PhoneNumber != phoneNumber && Input.PhoneNumber != null)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.PhoneNumber = Input.PhoneNumber;
                var update = await _userManager.UpdateAsync(user);
                if (!update.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //name güncelleme
            if (Input.Name != name && Input.Name != null)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.Name = Input.Name;
                var update = await _userManager.UpdateAsync(user);
                if (!update.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //surname güncelleme
            if (Input.Surname != surname && Input.Surname != null)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.Surname = Input.Surname;
                var update = await _userManager.UpdateAsync(user);
                if (!update.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //instagram güncelleme
            if (Input.SocialInstagram != instagram)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.SocialInstagram = Input.SocialInstagram;
                var update = await _userManager.UpdateAsync(user);
                if (!update.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //snapchat güncelleme
            if (Input.SocialSnapchat != snapchat)
            {
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.SocialSnapchat = Input.SocialSnapchat;
                var update = await _userManager.UpdateAsync(user);
                if (!update.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profiliniz başarıyla güncellenmiştir!";
            return RedirectToPage();
        }
    }
}
