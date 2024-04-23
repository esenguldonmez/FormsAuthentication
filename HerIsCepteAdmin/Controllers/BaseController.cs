using HerIsCepteAdmin.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerIsCepteAdmin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// we inherit all controllers from this basecontroller.
        /// basicly we access usercontext data from all controllers by user variable
        /// User.FirstName + " " + User.LastName
        /// </summary>
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}