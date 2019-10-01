using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions
{
    /// <summary>
    /// Принимаемая модель конкретной даты, либо диапазона в формате Unixtimestamp, для выполнения фильтрации по определенному полю.
    /// </summary>
    public class DatePostViewModel
    {
        /// <summary>
        /// Больше чем.
        /// </summary>
        [Range(default, 2147483647, ErrorMessage = "Недопустимое значение даты в формате Unixtimestamp.")]
        public long? MoreThan { get; set; } = null;

        /// <summary>
        /// Меньше чем.
        /// </summary>
        [Range(default, 2147483647, ErrorMessage = "Недопустимое значение даты в формате Unixtimestamp.")]
        public long? LessThan { get; set; } = null;

        /// <summary>
        /// Равна.
        /// </summary>
        [Range(default, 2147483647, ErrorMessage = "Недопустимое значение даты в формате Unixtimestamp.")]
        public long? Equal { get; set; } = null;

        /// <summary>
        /// Находится в диапазоне.
        /// </summary>
        public DateRangePostViewModel Range { get; set; } = null;
    }
}