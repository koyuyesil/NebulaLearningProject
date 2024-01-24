using NebulaLearning.Core.Net4x.CrossCuttingConserns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebulaLearning.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {

        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(new Guid(), "koyuyesil", "koyuyesil@anitr.net", DateTime.Now.AddDays(15), new[] { "Admin,Editor" }, false, "Örsan", "Nuhoğlu");
            return "User is authenticated!";
        }
    }
}