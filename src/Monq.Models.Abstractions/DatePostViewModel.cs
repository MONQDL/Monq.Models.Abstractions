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
        [Range(default, int.MaxValue, ErrorMessage = "Invalid date value in Unixtimestamp format.")]
        public long? MoreThan { get; set; } = null;

        /// <summary>
        /// Меньше чем.
        /// </summary>
        [Range(default, int.MaxValue, ErrorMessage = "Invalid date value in Unixtimestamp format.")]
        public long? LessThan { get; set; } = null;

        /// <summary>
        /// Равна.
        /// </summary>
        [Range(default, int.MaxValue, ErrorMessage = "Invalid date value in Unixtimestamp format.")]
        public long? Equal { get; set; } = null;

        /// <summary>
        /// Меньше чем или равно.
        /// </summary>
        [Range(default, int.MaxValue, ErrorMessage = "Invalid date value in Unixtimestamp format.")]
        public long? LessThanOrEqual { get; set; } = null;

        /// <summary>
        /// Больше чем или равно.
        /// </summary>
        [Range(default, int.MaxValue, ErrorMessage = "Invalid date value in Unixtimestamp format.")]
        public long? MoreThanOrEqual { get; set; } = null;

        /// <summary>
        /// Находится в диапазоне.
        /// </summary>
        public DateRangePostViewModel? Range { get; set; } = null;
    }
}