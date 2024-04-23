using HerIsCepteAdmin.DAL.Security;
using HerIsCepteAdmin.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace HerIsCepteAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null && !authTicket.Expired)
                {
                    // Kullanıcı bilgilerini çözümle
                    var serializeModel = JsonConvert.DeserializeObject<PrincipalModel>(authTicket.UserData);

                    // Hatırlama işlevselliğini kontrol et
                    bool rememberMe = authTicket.IsPersistent;

                    // Oturum süresi (cookie ömrü) belirleme
                    DateTime expirationDate = rememberMe
                        ? DateTime.Now.AddMonths(1)  // Örnek olarak 1 ay süreyle hatırla
                        : DateTime.Now.AddMinutes(5);   // Örnek olarak 1 saat süreyle hatırlama yok

                    // Yeni bir kimlik oluştur
                    var newUser = new CustomPrincipal(authTicket.Name, serializeModel.UserId, serializeModel.Email);

                    // Yeni kimliği ayarla
                    HttpContext.Current.User = newUser;

                    // Hatırlama cookie'sini güncelle
                    var newAuthTicket = new FormsAuthenticationTicket(
                        authTicket.Version,
                        authTicket.Name,
                        DateTime.Now,
                        expirationDate,
                        rememberMe,
                        authTicket.UserData,
                        authTicket.CookiePath);

                    var newEncryptedTicket = FormsAuthentication.Encrypt(newAuthTicket);
                    var newHttpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, newEncryptedTicket)
                    {
                        Expires = expirationDate,
                        HttpOnly = true
                    };

                    Response.Cookies.Set(newHttpCookie);
                }
            }
        }
    }
}
