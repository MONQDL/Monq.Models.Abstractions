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
        [Required(ErrorMessage = "Не указана начальная точка диапазона дат.")]
        [Range(default, 2147483647, ErrorMessage = "Недопустимое значение начальной точки диапазона дат в формате Unixtimestamp.")]
        public long Start { get; set; }

        /// <summary>
        /// Конечная точка диапазона.
        /// </summary>
        [Required(ErrorMessage = "Не указана конечная точка диапазона дат.")]
        [Range(default, 2147483647, ErrorMessage = "Недопустимое значение конечной точки диапазона дат в формате Unixtimestamp.")]
        public long End { get; set; }
    }
}