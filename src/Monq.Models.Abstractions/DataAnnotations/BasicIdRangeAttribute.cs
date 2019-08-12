using System;
using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions.DataAnnotations
{
    /// <summary>
    /// Модификация <see cref="RangeAttribute"/> для типа <see cref="BasicIdPostViewModel"/>.
    /// </summary>

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class BasicIdRangeAttribute : RangeAttribute
    {
        /// <inheritdoc />
        public BasicIdRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
        }

        /// <inheritdoc />
        public BasicIdRangeAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
        }

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