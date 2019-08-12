namespace Monq.Models.Abstractions
{
    /// <summary>
    /// Модель данных используется в запросах на привязку данных между собой при добавлении и обновлении объектов.
    /// К примеру КЕ -> Тип КЕ. Модель добавления КЕ: { "name": "123", "ciType": { "id": 200 } }.
    /// </summary>
    public class BasicIdPostViewModel
    {
        /// <summary>
        /// Id сущности для создания.
        /// </summary>
        public long Id { get; set; }
    }
}