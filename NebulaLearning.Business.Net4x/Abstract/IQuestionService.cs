using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Abstract
{
    public interface IQuestionService
    {
        Question Add(Question question);

        Question Update(Question question);

        Question Delete(Question question);

        Question GetById(int id);

        List<Question> GetList();

        List<Question> GetByCategoryId(int id);
    }
}
