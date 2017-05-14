using System.Web.Mvc;
using AutoMapper;
using PANWebApp.DAL;
using PANWebApp.DAL.DTO;
using PANWebApp.Helpers;
using PANWebApp.Models;
using PANWebApp.Services;

namespace PANWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AuthenticationService _authenticationService;
        private DataAccess _dataAccess;

        public AccountController()
        {
            _dataAccess = new DataAccess();
            _authenticationService = new AuthenticationService();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Account
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = CryptoHelper.CalulateHash(loginViewModel.Password);

                if (_dataAccess.UserExists(loginViewModel.Login, hashedPassword))
                {
                    _authenticationService.LogIn(loginViewModel.Login, loginViewModel.RememberMe);
                }
            }

            return RedirectToAction("Index", "Home");
        }
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_dataAccess.UserExists(registerViewModel.Login))
                {


                    UserDTO userDTO = Mapper.Map<UserDTO>(registerViewModel);
                    userDTO.PasswordHash = CryptoHelper.CalulateHash(registerViewModel.Password);

                    _dataAccess.CreateNewUser(userDTO);
                    _dataAccess.SaveChanges();
                    _authenticationService.LogIn(registerViewModel.Login);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logoff()
        {
            _authenticationService.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}