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
            
            return value.Behavior switch
            {
                ModelPropertyPutBehavior.Override => value.Value,
                ModelPropertyPutBehavior.Append => targetProp + value.Value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}