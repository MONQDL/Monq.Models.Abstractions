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
        public string Value { get; set; } = null;

        /// <summary>
        /// Проверять, существует ли данное значение в обновляемой строке.
        /// </summary>
        public bool CheckExistingSubstring { get; set; } = false;

        /// <summary>
        /// Поведение при обновлении свойства сущности.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelPropertyPutBehavior Behavior { get; set; } = ModelPropertyPutBehavior.Override;
    }
}