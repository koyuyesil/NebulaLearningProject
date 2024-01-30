using AutoMapper;
using System.Collections.Generic;

namespace NebulaLearning.Core.Net4x.Utilities.Mappings
{
    // class tamamen yanlış kullanılmıştır
    // SADECE ÖRNEK KULLANIMI YANLIŞ Mapper initialize tek sefer çalıştırılabilir
    // TODO : WEB API STEP 8 : AutoMapper IoC kullanılarak bir class a taşınır.
    public class AutoMapperHelper
    {
        // TODO : AUTOMAPPER STEP 2 :
        public static List<T> MapToSameTypeList<T>(List<T> entityList)
        {
            // AutoMapper Inititalize tek sefer yapılabilir.
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });
            List<T> result = Mapper.Map<List<T>, List<T>>(entityList);
            return result;
        }
        // TODO : AUTOMAPPER STEP 3 :
        public static T MapToSameTypeList<T>(T obj)
        {
            // AutoMapper Inititalize tek sefer yapılabilir.
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });
            T result = Mapper.Map<T, T>(obj);
            return result;
        }
    }
}
