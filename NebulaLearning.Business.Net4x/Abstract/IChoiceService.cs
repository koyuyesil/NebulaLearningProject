using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.ServiceModel;

namespace NebulaLearning.Business.Net4x.Abstract
{
    [ServiceContract]
    public interface IChoiceService
    {
        [OperationContract]
        Choice Add(Choice choice);

        [OperationContract]
        Choice Update(Choice choice);

        [OperationContract]
        Choice Delete(Choice choice);

        [OperationContract]
        Choice GetById(int id);

        [OperationContract]
        List<Choice> GetList();

        [OperationContract]
        List<Choice> GetByQuestionId(int id);
    }
}