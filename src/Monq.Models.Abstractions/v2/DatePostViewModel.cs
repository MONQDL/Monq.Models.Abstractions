using System;

namespace Monq.Models.Abstractions.v2
{
    /// <summary>
    /// Принимаемая модель конкретной даты, либо диапазона, для выполнения фильтрации по определенному полю.
    /// </summary>
    public class DatePostViewModel
    {
        /// <summary>
        /// Больше чем.
        /// </summary>
        public DateTimeOffset? MoreThan { get; set; } = null;

        /// <summary>
        /// Меньше чем.
        /// </summary>
        public DateTimeOffset? LessThan { get; set; } = null;

        /// <summary>
        /// Равна.
        /// </summary>
        public DateTimeOffset? Equal { get; set; } = null;

        /// <summary>
        /// Меньше чем или равно.
        /// </summary>
        public DateTimeOffset? LessThanOrEqual { get; set; } = null;

        /// <summary>
        /// Больше чем или равно.
        /// </summary>
        public DateTimeOffset? MoreThanOrEqual { get; set; } = null;

        /// <summary>
        /// Находится в диапазоне.
        /// </summary>
        public DateRangePostViewModel? Range { get; set; } = null;
    }
}