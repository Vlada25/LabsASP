using AutoMapper;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.ASP.Controllers
{
    public class AccountsController : Controller
    {
        /*
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AccountsController(IAuthenticationManager authManager,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _authManager = authManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (loginUser == null)
            {
                ViewData["Message"] = "LoginUser object sent from client is null.";
                return View();
            }

            if (!await _authManager.ValidateUser(loginUser))
            {
                ViewData["Message"] = "Authentication failed. Wrong user name or password.";
                return View();
            }

            string token = await _authManager.CreateToken();

            Response.Cookies.Append("X-Access-Token", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(5)
            });

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                ViewData["Message"] = ModelState;
                return View();
            }

            return RedirectToRoute(new { controller = "Accounts", action = "Login" });
        }
        */
    }
}
