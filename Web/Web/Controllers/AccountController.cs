using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        //AccountController
        //UserManager : createUser(), deleteUser(), GenerateToken(), FindByIdAsync(), ConfirmEmailAsync()
        //SignInManager: SignIn, SignOut()
        private UserManager<ApplicationUser> _userManager { get; }
        private SignInManager<ApplicationUser> _signInManager { get; }

        //Dependency Injection for Usermanager, SIgnInManager
        public AccountController(UserManager<ApplicationUser> userManager, 
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.title = "Join Member";
            return View(new RegisterViewModel());
        }

        //When creating a webform it is highly important to have anti-forgery tokens generated for the user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //user변수와 비밀번호를 넘긴다.
                var user = new ApplicationUser { 
                    UserName = model.Email, 
                    Email = model.Email,
                    FullName = model.FullName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    //Put it on a breakpoint and get the URL below. And after restarting, go to the login page and log in. 
                    //https://localhost:5001/Account/ConfirmEmail?userId=bfcc19fb-19e6-4688-9936-fe7a942efda8&token=CfDJ8PWsFzhZKSxKir%2FE10rRpJWM2eeYDfkFOMNl0KCG3g%2BlDS66cmDb0NmFh0u5eA4jPrCpU1UUgbGT7xgoBbcwRjV0U%2BsWULGaxNYLSuOvMZXze3DNrZ4RYmqZzqm8enpFj8B1mjNFe6TFFIKbyB8PqkLrIsgwiIYigtEva82ErpQ0fHImJ4kLVKCphthhv5RDIZ%2FBagALx8xxXT0ht0QxttQ5Smr%2BuMrGV%2FLGJdmQmfwTGnmCqkPZkmkG2eKAnmV27Q%3D%3D
                    //token generate, verification to send email 
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //create link then when user click link, then, ("anyName","controllerName",AnnynoneoumOBject)
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
                    //send to the email - you have the email address. create confirmation URL
                    await System.IO.File.WriteAllTextAsync("confLink.text", confirmationLink.ToString());
                    ViewBag.ErrorTitle = "Registraion is successful";
                    ViewBag.ErrorMessage = "Before you login, please login to your email address" + model.Email + " and click link" ;
                    return View("Error");
                }
                //에러발생시, 
                foreach(var e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            return View(model);
        }

        //Pass to new { userId = user.Id, token = token }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            //If no value is passed, it will move to account/register
            if (null == userId || null == token) RedirectToAction("Regsiter");

            //Find a user with userid using FindByIdAsync.
            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.ErrorTitle = "";

            if (null == user)
            { 
                ViewBag.ErrorMessage = userId + "is null";
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.ErrorMessage = "Registration is successfull";
                return RedirectToAction("Login", "Account");
            }
            ViewBag.ErrorMessage = "Email could not be confirmed";
            return View("Error");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.title = "Login";
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //_signInManager안에 PasswordSignInAsync함수에다가 받은 이메일과 비번을 넘긴다. 
                //세번째 false는 브라우저가 닫혀도 로그인된 쿠키가 계속 지속될지여부. 
                //네번쨰 false는 유저가 로그인 실패시, 계정을 잠가야할지 여부. 
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    var userID = user.Id;

                    //Create session with userId and model.Email.
                    //it allows us to use those session in other page. 
                    HttpContext.Session.SetString("userid", userID);
                    HttpContext.Session.SetString("userEmail", model.Email);

                    if (HttpContext.Session.GetString("userEmail") == "admin@gmail.com" )
                    {
                        return RedirectToAction("list3", "Admin");
                    }

                    if (HttpContext.Session.GetString("userid") == null)
                    {
                        return RedirectToAction("Login", "Account");
                    } else
                    {
                        return RedirectToAction("Detail", "Interview");
                    }
                    
                   
                }
                //실패시, 
                ModelState.AddModelError("", "Invalid attempt");
            }
            return View(model); 
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account"); 
        }
    }
}
