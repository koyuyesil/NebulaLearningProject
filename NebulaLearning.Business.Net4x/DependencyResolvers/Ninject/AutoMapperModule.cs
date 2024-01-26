using AutoMapper;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.Concrete.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Business.Net4x.DependencyResolvers.Ninject
{
    // TODO : AUTOMAPPER STEP 4 :
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            // ToConstant new ile türetilemeyen statik nesneler için
            Bind<IMapper>().ToConstant(CreateMapperConfiguration().CreateMapper()).InSingletonScope();
        }

        private MapperConfiguration CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(GetType().Assembly); // GetType().Assembly derlenmiş dosya daki profil türündekileri bulur
            });
            return config;
        }
    }
}
