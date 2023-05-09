using CompsKitMarket.Core.Entities.Identity;
using CompsKitMarket.Core.Repositories;
using CompsKitMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompsKitMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        private readonly UsersRepository _usersRepository;

        public AccountController(UserManager<User> userManager, RoleManager<Role> roleManager, 
            SignInManager<User> signInManager, UsersRepository usersRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            _usersRepository = usersRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new UserModel
            {
                Surname = user.Surname,
                Name = user.Name,
                SecondName = user.SecondName,
                Login = user.UserName,
                Mobile = user.PhoneNumber,
                Address = user.Address,
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Surname = model.Surname;
            user.Name = model.Name;
            user.SecondName = model.SecondName;

            user.PhoneNumber = model.Mobile;
            user.Address = model.Address;

            user.UserName = model.Login;
            user.NormalizedUserName = model.Login.ToUpper();

            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                TempData["Success"] = "Успешно";
                return RedirectToAction("Index", "Account");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(string.Empty, item.Description);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
                return View(model);
            }
        }

        public IActionResult Registration()
        {
            var model = new RegisterModel();
            return View("Registration", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User user = new User
            {
                UserName = model.Login,
                NormalizedUserName = _userManager.NormalizeName(model.Login),
                Surname = model.Surname,
                Name = model.Name,
                SecondName = model.SecondName,
                PhoneNumber = model.Mobile,
                Address = model.Address,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(string.Empty, item.Description);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
