using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NebulaLearning.WebAPI.MessageHandlers
{
    // TODO : AuthenticationHandler STEP 1:
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    //oauth burada kullanılabilir.
                    byte[] base64data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(base64data);
                    string[] tokenValues = decodedString.Split(':');

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    User user = userService.GetUserByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user != null)
                    {
                        var roles = userService.GetUserRoles(user).Select(u => u.RoleName).ToArray();
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), roles);
                        Thread.CurrentPrincipal = principal; // APP
                        HttpContext.Current.User = principal; // TARAYICI
                    }
                }
            }
            catch (Exception)
            {
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}