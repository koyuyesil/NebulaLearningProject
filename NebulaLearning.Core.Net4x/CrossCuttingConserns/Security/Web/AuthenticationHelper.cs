using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string userName, string email, DateTime expiration, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, CreateAuthText(email, roles, firstName, lastName, id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //FormsAuthentication.FormsCookieName ASP.NET Standart auth cookie ismini döndürür.
        }

        private static string CreateAuthText(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email).Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]).Append(",");
            }
            stringBuilder.Remove(stringBuilder.Length-1, 1).Append("|");

            stringBuilder.Append(firstName).Append("|");
            stringBuilder.Append(lastName).Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}
