namespace Monq.Models.Abstractions
{
    /// <summary>
    /// Поведение при обновлении свойства сущности.
    /// </summary>
    public enum ModelPropertyPutBehavior : byte
    {
        /// <summary>
        /// Перезаписать значение.
        /// </summary>
        Override,

        /// <summary>
        /// Дописать к существующему.
        /// </summary>
        Append
    }
}