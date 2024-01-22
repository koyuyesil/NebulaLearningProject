using FluentValidation;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity) // HACK Açık tür dönüşümü yapıldı kontrol gerekli
        {
            var context = new ValidationContext<object>(entity);// bu şekilde güncellendi son sürüm
            var result = validator.Validate(context);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);//Fluent validationdan gelmeli dikkat edelim
            }
        }
    }
}
