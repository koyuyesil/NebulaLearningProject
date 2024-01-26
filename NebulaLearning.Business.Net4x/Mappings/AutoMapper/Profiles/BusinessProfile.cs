using AutoMapper;
using NebulaLearning.Entities.Net4x.Concrete;



namespace NebulaLearning.Business.Net4x.Mappings.AutoMapper.Profiles
{
    // TODO : AUTOMAPPER STEP 5 :
    public class BusinessProfile:Profile // Profile : AutoMapper den geliyor
    {
        public BusinessProfile()
        {
            CreateMap<Exam, Exam>();
        }
    }
}
