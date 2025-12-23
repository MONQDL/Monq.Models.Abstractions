using System.ComponentModel.DataAnnotations;

namespace Monq.Models.Abstractions
{
    /// <summary>
    /// Принимаемая модель диапазона дат в формате Unixtimestamp, для выполнения фильтрации по определенному полю.
    /// </summary>
    public class DateRangePostViewModel
    {
        /// <summary>
        /// Начальная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "The starting point of the date range was not specified.")]
        [Range(default, long.MaxValue, ErrorMessage = "Invalid value for starting point of date range in Unixtimestamp format.")]
        public long Start { get; set; }

        /// <summary>
        /// Конечная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "The end point of the date range was not specified.")]
        [Range(default, long.MaxValue, ErrorMessage = "Invalid date range endpoint value in Unixtimestamp format.")]
        public long End { get; set; }
    }
}
