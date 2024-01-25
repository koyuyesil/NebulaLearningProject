using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Security;
using System.Threading;

namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.AuthorizationAspects
{
    [PSerializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            foreach (string role in roles)
            {
                if (Thread.CurrentPrincipal.IsInRole(role))
                {
                    isAuthorized = true;
                }
            }
            if (!isAuthorized) { throw new SecurityException("You're not authorized!"); }
        }
    }
}
