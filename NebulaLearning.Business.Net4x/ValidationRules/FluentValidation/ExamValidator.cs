using FluentValidation;
using NebulaLearning.Entities.Net4x.Concrete;
using System;



namespace NebulaLearning.Business.Net4x.ValidationRules.FluentValidation
{
    //burada namespace IEntity den dolayı Core katmanının da implementasyonunu gerektirir unutma hata verir
    public class ExamValidator:AbstractValidator<Exam>
    {
        public ExamValidator() {
            RuleFor(e => e.ExamCategoryId).NotEmpty().WithMessage("Boş Olamaz");
            RuleFor(e => e.ExamName).NotEmpty();
            RuleFor(e => e.ExamDescription).NotEmpty();
            RuleFor(e => e.ExamDuration).NotEmpty();
            RuleFor(e => e.ExamResult).NotEmpty();
            RuleFor(e => e.ExamResult).NotEmpty().Must(MustTrue);


        }

        private bool MustTrue(int arg)
        {
           return true; 
        }
    }
}
