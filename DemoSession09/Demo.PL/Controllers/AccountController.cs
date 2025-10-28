using Demo.DAL.Models.IdentityModel;
using Demo.PL.Utilities;
using System.Web;
using Demo.PL.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Demo.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,SignInManager <ApplicationUser> _signInManager ) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model) 
        {
            if(!ModelState.IsValid) return View(model);

            var userToAdd = new ApplicationUser()
            { UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            };
            var res=_userManager.CreateAsync(userToAdd,model.Password).Result;
            if (res.Succeeded) return RedirectToAction("Login");
            else 
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
                return View(model);
            }
           
        }

        [HttpGet]
        public IActionResult Login() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Login( LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user=_userManager.FindByEmailAsync(model.Email).Result;
            if (user is not null)
            {
                var isCorrectpass = _userManager.CheckPasswordAsync(user, model.Password).Result;
                if (isCorrectpass)
                {
                    var res = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;
                    if (res.IsNotAllowed) ModelState.AddModelError(string.Empty, "Your Account Is Not Allowed");

                    if (res.Succeeded) return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            else ModelState.AddModelError(string.Empty, "Invalid Login");

                return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ForgetPassword() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid) 
            {
            var user=_userManager.FindByEmailAsync(model.Email).Result;
                if (user is not null) 
                {
                    var token=_userManager.GeneratePasswordResetTokenAsync(user).Result;
                    token = HttpUtility.UrlEncode(token);

                    var resetPasswordLink = Url.Action("ResetPassword", "Account",
                new { email = model.Email, token = token },
                Request.Scheme);

                    var mail = new Email()
                    {
                        To=model.Email
                        ,Subject="Reset Password",
                        Body= resetPasswordLink
                    };
                    //send email
                   var res= EmailSetting.SendEmail(mail);
                    if(res) return RedirectToAction(nameof(CheckYourInbox));
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgetPassword),model);
        }
        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }

       
        public IActionResult ResetPassword(string email ,string token) 
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                return BadRequest("Invalid password reset link.");

            token = HttpUtility.UrlDecode(token);
            TempData["email"]=email;
            TempData["token"]=token;
           
            TempData.Keep();
            return View();
        }


      




        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var email = TempData["email"] as string;    
            var token = TempData["token"] as string;
            TempData.Keep();

            var user=_userManager.FindByEmailAsync(email).Result;

            if (user is not null) {

                var res=_userManager.ResetPasswordAsync(user,token,model.Password).Result;
                if (res.Succeeded) return RedirectToAction(nameof(Login));
                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                    }

            return View(model);
        }
    }
}
