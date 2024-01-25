using FluentValidation;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Validation.FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Linq;

namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects
{

    [PSerializable] // Aspect serileştirilebilir olmalı
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validaetype;

        public FluentValidationAspect(Type validaetype)
        {
            _validaetype = validaetype;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validaetype);// (IValidator) açık dönüşümü eklemeyi unutma      
            // NebulaLearning.Business.Net4x.ValidationRules.FluentValidation.ExamValidator:AbstractValidator<Exam>
            var entityType = _validaetype.BaseType.GetGenericArguments()[0]; // Yukarıdaki namespacedeki 0'ıncı argumana (Exam) denk gelir.
            // Notasyonun çalıştırılacağı methodun argümanıyla eşleştir. BondaryAspect yazılan methodun argümanını kontrol eder.
            var entities = args.Arguments.Where(t => t.GetType() == entityType); // ToList() yapılabilir.
            foreach (var entity in entities) { ValidatorTool.FluentValidate(validator, entity); }
            //args.Arguments.Where(t => t.GetType() == entityType).ToList().ForEach(entity => ValidatorTool.FluentValidate(validator, entity));



        }
    }
}
