using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions.DataAnnotations
{
    /// <summary>
    /// Модификация <see cref="RequiredAttribute"/> для коллекции типа <see cref="IEnumerable"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class NotEmptyAttribute : RequiredAttribute
    {
        /// <inheritdoc />
        public override bool IsValid(object value)
            => value is IEnumerable list && list.GetEnumerator().MoveNext();
    }
}