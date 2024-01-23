using FluentValidation;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Entities.Net4x.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Business.Net4x.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Exam>>().To<ExamValidator>().InSingletonScope();
        }
    }
}
