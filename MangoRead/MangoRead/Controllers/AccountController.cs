using MangoRead.Domain.Models.Account;
using MangoRead.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace MangoRead.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public ApplicationUser CurrentUser { get; set; }

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IUserStore<ApplicationUser> userStore
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            var register = new RegisterViewModel()
            {
                ReturnUrl = returnUrl,
            };

            return View(register);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { 
                    Email = model.Email, 
                    FirstName = model.FirstName, 
                    LastName = model.LastName,
                    IsOverEighteen = model.IsOverEighteen,
                    ProfilePicture = model.ProfilePicture,
                };

                await this._userStore.SetUserNameAsync(user, user.FirstName, CancellationToken.None);
                await this._emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            /*this.UserModel = await this._userManager.GetUserAsync(HttpContext.User);*/
            var name = HttpContext.User.Identity.Name;
            this.CurrentUser = this._userManager.Users.Where(x => x.UserName.Equals(name)).SingleOrDefault();
            return View(this.CurrentUser);
        }
        /*
                [HttpPost]
                public async Task<IActionResult> Index()
                {
                    // удаляем аутентификационные куки
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("../Index");
                }*/

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Request.Headers["Referer"].ToString();
            }

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = model.Email;
                if (IsValidEmail(model.Email))
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        userName = user.UserName;
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login or password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
