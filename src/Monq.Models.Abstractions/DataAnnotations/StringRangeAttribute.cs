using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions.DataAnnotations
{
    /// <summary>
    /// Атрибут для валидации возможных значений строкового типа.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class StringRangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Диапазон доступных значений.
        /// </summary>
        public string[] AllowedValues { get; set; }

        /// <summary>
        /// Инициализирует атрибут валидации возможных значений строкового типа.
        /// </summary>
        /// <param name="allowedValues">Диапазон доступных значений.</param>
        public StringRangeAttribute(params string[] allowedValues) => AllowedValues = allowedValues;

        /// <inheritdoc />
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (value)
            {
                case null:
                case string strVal when AllowedValues.Contains(strVal, StringComparer.InvariantCultureIgnoreCase):
                    return ValidationResult.Success;
                case string strVal:
                    return new ValidationResult($"The specified value is not in the list of valid values: {string.Join(", ", AllowedValues)}.");
                case IEnumerable<string> strEnum when !strEnum.Any():
                    return ValidationResult.Success;
                case IEnumerable<string> strEnum when strEnum.All(s => AllowedValues.Contains(s, StringComparer.InvariantCultureIgnoreCase)):
                    return ValidationResult.Success;
                case IEnumerable<string> strEnum:
                    return new ValidationResult($"Found values that are not in the list of valid values: {string.Join(", ", AllowedValues)}.");
                default:
                    return new ValidationResult($"This type is not a string or an array of strings.");
            }
        }
    }
}