using FluentValidation;
using NebulaLearning.Entities.Net4x.Concrete;



namespace NebulaLearning.Business.Net4x.ValidationRules.FluentValidation
{
    // Burada namespace IEntity den dolayı Core katmanının da implementasyonunu gerektirir unutma hata verir
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(e => e.CategoryId).NotEmpty().WithMessage("Boş olamaz!").LessThan(5).WithMessage("5'ten küçük olmalı!").GreaterThan(0).WithMessage("0'dan büyük olmalı!");
            RuleFor(e => e.Name).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.Duration).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.Result).NotEmpty().WithMessage("Boş olamaz!");
            RuleFor(e => e.Result).NotEmpty().WithMessage("Boş olamaz!");
            //RuleFor(e => e.ExamResult).NotEmpty().Must(MustTrue); // MustTrue() methodu ile kullanım.


        }
        // MustTrue() methodu
        private bool MustTrue(int arg)
        {
            return true;
        }
    }
}
