using System;

namespace Monq.Models.Abstractions.Helpers
{
    /// <summary>
    /// Хелпер для работы с моделями.
    /// </summary>
    public static class ModelHelper
    {
        /// <summary>
        /// Возвращает новое значение, если переданное значение отличается и не пустая строка.
        /// <para>
        /// В зависимости от переданного поведения в принимаемой модели будет возвращено соответствующее значение.
        /// </para>
        /// </summary>
        /// <param name="targetProp">Исходное значение, которое будет обновлено.</param>
        /// <param name="value">Принимаемая модель представления для обновления свойства сущности.</param>
        /// <returns></returns>
        public static string Update(string targetProp, ModelPropertyPutViewModel value)
        {
            if (value?.Value == null)
                return targetProp;

            if (targetProp == null)
                return value.Value;

            if (targetProp.Equals(value.Value) && value.Behavior == ModelPropertyPutBehavior.Override)
                return targetProp;

            if (value.CheckExistingSubstring && targetProp.Contains(value.Value))
                return targetProp;

            return value.Behavior switch
            {
                ModelPropertyPutBehavior.Override => value.Value,
                ModelPropertyPutBehavior.Append when !value.AppendWithNewLine => targetProp + value.Value,
                ModelPropertyPutBehavior.Append when value.AppendWithNewLine => AppendLine(targetProp, value.Value),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        static string AppendLine(string targetProp, string newValue)
        {
            if (string.IsNullOrWhiteSpace(targetProp))
                return targetProp + newValue;

            if (targetProp.EndsWith(Environment.NewLine) || newValue.StartsWith(Environment.NewLine))
                return targetProp + newValue;

            return targetProp + Environment.NewLine + newValue;
        }
    }
}