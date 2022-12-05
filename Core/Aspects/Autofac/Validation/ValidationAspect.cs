
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.AspectMessages;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validator;
        public ValidationAspect(Type validator)
        {
            if (typeof(IValidator).IsAssignableFrom(validator))
            {
                throw new Exception(AspectMessages.WrongException);
            }
            validator = _validator;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validator);
            var entityType = _validator.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t=> t.GetType() == entityType);
            foreach ( var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
