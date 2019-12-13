using System;
using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions.DataAnnotations
{
    /// <summary>
    /// Модификация <see cref="RequiredAttribute"/> для типа <see cref="BasicIdPostViewModel"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class BasicIdRequiredAttribute : RequiredAttribute
    {
        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            if (value != null && value is BasicIdPostViewModel basicIdModel)
                return base.IsValid(basicIdModel.Id);
            else
                return false;
        }
    }
}