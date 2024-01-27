using System;
using System.Collections.Generic;
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
    public class AuthenticationHandler:DelegatingHandler
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
                    string decodedString=Encoding.UTF8.GetString(base64data);
                    string[] tokenValues = decodedString.Split(':');
                    if (tokenValues[0] == "koyuyesil" && tokenValues[1]=="155221")
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), new[] {"Editor"});
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