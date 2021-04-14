using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Monq.Models.Abstractions
{
    /// <summary>
    /// Принимаемая модель представления для обновления свойства сущности.
    /// </summary>
    public class ModelPropertyPutViewModel
    {
        /// <summary>
        /// Новое значение.
        /// </summary>
        public string? Value { get; set; } = null;

        /// <summary>
        /// Проверять, существует ли данное значение в обновляемой строке.
        /// </summary>
        public bool CheckExistingSubstring { get; set; } = false;

        /// <summary>
        /// Добавить перенос на новую строку перед ставкой нового значения к существующему.
        /// </summary>
        /// <remarks>
        /// Флаг имеет силу, если <see cref="Behavior"/> = <see cref="ModelPropertyPutBehavior.Append"/>.
        /// </remarks>
        public bool AppendWithNewLine { get; set; } = false;

        /// <summary>
        /// Поведение при обновлении свойства сущности.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelPropertyPutBehavior Behavior { get; set; } = ModelPropertyPutBehavior.Override;
    }
}