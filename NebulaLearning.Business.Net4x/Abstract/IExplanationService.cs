using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Abstract
{
    public interface IExplanationService
    {
        Explanation Add(Explanation explanation);

        Explanation Update(Explanation explanation);

        Explanation Delete(Explanation explanation);

        Explanation GetById(int id);

        List<Explanation> GetList();

        List<Explanation> GetByQuestionId(int id);
    }
}
