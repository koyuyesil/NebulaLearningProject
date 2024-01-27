using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
    // TODO : Önce ExamManager new lenir gereksinimleri görülür sonra modül olarak eklediğimiz InstanceFactory ile enekte edilir.
    // Hata vermez dikkat et factory e git ve parametre olarak modülleri ekle
    private IExamService examService = InstanceFactory.GetInstance<IExamService>();
    public Exam AddExam(Exam exam)
    {
        return examService.AddExam(exam);
    }

    public Exam GetExamById(int id)
    {
        return examService.GetExamById(id);
    }

    public List<Exam> GetExamList()
    {
        return examService.GetExamList();
    }

    public void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam)
    {
        examService.TransactionalOperation(toInsertExam, toUpdateExam);
    }

    public Exam UpdateExam(Exam exam)
    {
        return examService.UpdateExam(exam);
    }
}