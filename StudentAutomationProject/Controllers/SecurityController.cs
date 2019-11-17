using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.Identity;
using StudentAutomationProject.Models.Security;

namespace StudentAutomationProject.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<SapIdentityUser> _userManager;
        private SignInManager<SapIdentityUser> _signInManager;

        public SecurityController(UserManager<SapIdentityUser> userManager, SignInManager<SapIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user != null)
            {
                ////Mail onay süreçleri 
                //if(!await _userManager.IsEmailConfirmedAsync(user))
                //{
                //    ModelState.AddModelError(String.Empty, "Email'i onayla");
                //}
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                //Yollanıcak Action yazılacak şimdilik boş
                return RedirectToAction();
            }

            ModelState.AddModelError(String.Empty, "Giriş Yapılamadı");
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //Yollanıcak Action yazılacak şimdilik boş
            return RedirectToAction();
        }

        public IActionResult AccessDenied()
        {
            //Yapılacak
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new SapIdentityUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);

                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });

                //Mail yollanıcak

                //yönlendirilecek action yazılacak
                return RedirectToAction();
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException("Kullanıcı Bulunamadı");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }

            return RedirectToAction();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return View();
            }

            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callBackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });

            //Send callback url with email
            return RedirectToAction("ForgotPasswordEmailSent");
        }

        public IActionResult ForgotPasswordEmailSent()
        {
            return View();
        }

        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("User Id or Code must me supplied for password reset");
            }

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

            if(user == null)
            {
                throw new ApplicationException("Kullanıcı bulunamadı");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirm");
            }
            return View();
        }
        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
    }
}