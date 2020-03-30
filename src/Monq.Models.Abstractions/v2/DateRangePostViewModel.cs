using System;
using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions.v2
{
    /// <summary>
    /// Принимаемая модель диапазона дат, для выполнения фильтрации по определенному полю.
    /// </summary>
    public class DateRangePostViewModel
    {
        /// <summary>
        /// Начальная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "Не указана начальная точка диапазона дат.")]
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// Конечная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "Не указана конечная точка диапазона дат.")]
        public DateTimeOffset End { get; set; }
    }
}