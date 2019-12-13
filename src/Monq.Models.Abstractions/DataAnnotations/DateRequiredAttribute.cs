using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Monq.Models.Abstractions.DataAnnotations
{
    /// <summary>
    /// Модификация <see cref="RequiredAttribute"/> для типа <see cref="DatePostViewModel"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class DateRequiredAttribute : RequiredAttribute
    {
        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            if (value != null && value is DatePostViewModel dateModel)
            {
                if (dateModel.Range != null && !dateModel.Equal.HasValue)
                {
                    var nestedPropsToValidate = typeof(DateRangePostViewModel)
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(p => p.IsDefined(typeof(ValidationAttribute)));

                    foreach (var property in nestedPropsToValidate)
                    {
                        var validators = GetCustomAttributes(property, typeof(ValidationAttribute)) as ValidationAttribute[];
                        if (validators == null || validators.Length == 0)
                            continue;

                        var propValue = property.GetValue(dateModel.Range);

                        foreach (var validator in validators)
                        {
                            var result = validator.GetValidationResult(propValue, new ValidationContext(dateModel.Range));
                            if (result == null || result == ValidationResult.Success) 
                                continue;

                            return false;
                        }
                    }

                    return true;
                }

                return dateModel.Equal.HasValue ||
                       dateModel.LessThan.HasValue ||
                       dateModel.LessThanOrEqual.HasValue ||
                       dateModel.MoreThan.HasValue ||
                       dateModel.MoreThanOrEqual.HasValue;
            }
            else
                return false;
        }
    }
}