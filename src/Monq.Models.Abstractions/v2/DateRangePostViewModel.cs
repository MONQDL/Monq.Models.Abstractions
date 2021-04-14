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
        [Required(ErrorMessage = "The starting point of the date range was not specified.")]
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// Конечная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "The end point of the date range was not specified.")]
        public DateTimeOffset End { get; set; }
    }
}