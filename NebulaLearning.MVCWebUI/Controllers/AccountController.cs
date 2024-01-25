using NebulaLearning.Business.Net4x.Abstract;
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
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string username, string password)
        {
            var user = _userService.GetUserByUserNameAndPassword(username, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    new[] { "Admin" },
                    false,
                    user.FirstName,
                    user.LastName);
                return "User is authenticated!";

            }
         return "User is not authenticated!";
        }
    }
}