using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Abstract
{
    public interface IChoiceService
    {
        Choice Add(Choice choice);

        Choice Update(Choice choice);

        Choice Delete(Choice choice);

        Choice GetById(int id);

        List<Choice> GetList();

        List<Choice> GetByQuestionId(int id);
    }
}
