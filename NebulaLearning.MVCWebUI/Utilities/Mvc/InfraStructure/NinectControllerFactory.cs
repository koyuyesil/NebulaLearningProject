using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NebulaLearning.MVCWebUI.Utilities.Mvc.InfraStructure
{
    public class NinectControllerFactory : DefaultControllerFactory
    {
        IKernel _kernel;

        public NinectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType==null?null:(IController)_kernel.Get(controllerType);
        }
    }
}