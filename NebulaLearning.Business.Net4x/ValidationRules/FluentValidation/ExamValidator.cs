using FluentValidation;
using NebulaLearning.Entities.Net4x.Concrete;



namespace NebulaLearning.Business.Net4x.ValidationRules.FluentValidation
{
    //burada namespace IEntity den dolayı Core katmanının da implementasyonunu gerektirir unutma hata verir
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(e => e.ExamCategoryId).NotEmpty().WithMessage("Boş olamaz!").LessThan(5).WithMessage("5'ten küçük olmalı!").GreaterThan(0).WithMessage("0'dan büyük olmalı!");
            RuleFor(e => e.ExamName).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.ExamDescription).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.ExamDuration).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.ExamResult).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.ExamResult).NotEmpty().WithMessage("Boş olamaz!");
            //RuleFor(e => e.ExamResult).NotEmpty().Must(MustTrue);// OLMALI METHODU İLE


        }
        // OLMALI METHODU
        private bool MustTrue(int arg)
        {
            return true;
        }
    }
}
