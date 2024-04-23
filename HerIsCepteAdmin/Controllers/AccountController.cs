using HerIsCepteAdmin.DAL;
using HerIsCepteAdmin.Models;
using HerIsCepteAdmin.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HerIsCepteAdmin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context = new DataContext();

        public ActionResult Index()
        {
            return HttpContext.User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _context.Admin.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Kullanıcı giriş yaptıktan sonra hatırlama işlevselliğini kontrol et
                    bool rememberMe = model.RememberMe;

                    // Oturum süresi (cookie ömrü) belirleme
                    DateTime expirationDate = rememberMe
                        ? DateTime.Now.AddMonths(1)  // Örnek olarak 1 ay süreyle hatırla
                        : DateTime.Now.AddHours(1);   // Örnek olarak 1 saat süreyle hatırlama yok

                    var principalModel = new PrincipalModel
                    {
                        UserId = user.ID,
                        Name = user.Name,
                        Email = user.Mail,
                        Department = user.Department
                    };

                    var userData = JsonConvert.SerializeObject(principalModel);
                    var authenticationTicket = new FormsAuthenticationTicket(
                        1,
                        user.Username,
                        DateTime.Now,
                        expirationDate,
                        rememberMe,
                        userData);

                    var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
                    var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        Expires = expirationDate,
                        HttpOnly = true
                    };

                    Response.Cookies.Add(httpCookie);

                    string redirectAction = "";

                    switch (user.Department)
                    {
                        case 1:
                            redirectAction = "Index";
                            break;
                        case 2:
                            redirectAction = "Index";
                            break;
                        default:
                            redirectAction = "Index";
                            break;
                    }

                    return RedirectToAction(redirectAction, user.Department == 1 ? "Home" : "Home");
                }

                ModelState.AddModelError("", "Yanlış kullanıcı adı veya şifre! Lütfen kontrol ediniz.");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                int UserType = -1;
                var userExists = _context.Users.FirstOrDefault(u => u.Name == model.Username && u.Mail == model.Email);
                if (userExists == null)
                {
                    //var existingRole = _context.Roles.FirstOrDefault(m => m.RoleName == "User");

                    if (UserType != -1)
                    {
                        // we create a new user object to put our incoming datas.
                        var user = new UserTable
                        {
                            Name = model.Username,
                            Mail = model.Email,
                            Password = model.Password,
                        };
                        // add user to existing role(user).
                        //existingRole.Users.Add(user);
                    }
                    _context.SaveChanges();
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            // Cookie'nin süresini sıfırla
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Login", "Account", null);
        }
    }
}