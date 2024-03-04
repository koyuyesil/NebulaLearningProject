using System.Collections.Generic;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;

/// <summary>
/// ProductService için özet açıklama
/// </summary>
public class ExamService: IExamService
{
    public ExamService()
    {
        // Önce ExamManager new lenir gereksinimleri görülür.
        // Sonra gereksinimler modül olarak, InstanceFactory ile enjekte edilir.
        // Hata vermez dikkat et factory e git ve parametre olarak modülleri ekle.
        // Core katmanında güvenlik etkin servis appde login yok unutma
    }

    private IExamService examService = InstanceFactory.GetInstance<IExamService>();

    public Exam Add(Exam exam)
    {
        return examService.Add(exam);
    }

    public Exam Update(Exam exam)
    {
        return examService.Update(exam);
    }

    public Exam Delete(Exam exam)
    {
        return examService.Delete(exam);
    }

    public Exam GetById(int id)
    {
        return examService.GetById(id);
    }

    public List<Exam> GetList()
    {
        return examService.GetList();
    }

    public void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam)
    {
        examService.TransactionalOperation(toInsertExam, toUpdateExam);
    }
}