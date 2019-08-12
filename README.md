# Monq.Models.Abstractions

В библиотеке представлены примитивы входных моделей, а также кастомные аттрибуты валидации.

<!-- TOC -->
[Monq.Models.Abstractions](#monqmodelsabstractions)
  - [Установка](#установка)
    - [Модели](#модели)
        - [I. BasicIdPostViewModel](#i-basicidpostviewmodel)
        - [II. DatePostViewModel](#ii-datepostviewmodel)
    - [Аттрибуты валидации](#аттрибуты-валидации)
      - [I. BasicIdRequiredAttribute](#i-basicidrequiredattribute)
      - [II. BasicIdRangeAttribute](#ii-basicidrangeattribute)
      - [II. StringRangeAttribute](#ii-stringrangeattribute)

<!-- /TOC -->

## Установка

```powershell
Install-Package Monq.Models.Abstractions -Source http://nuget.monq.ru/nuget/Default
```

## Модели

#### I. BasicIdPostViewModel

> Модель данных используется в запросах на привязку данных между собой при добавлении и обновлении объектов. 

##### Пример:

```CSharp
/// <summary>
/// Принимаемая модель для создания синтетического триггера.
/// </summary>
public class GateSyntheticTriggerPostViewModel
{
    /// <summary>
    /// Рабочая группа-владелец.
    /// </summary>
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }

    ...
}
```

```JS
{
  "ownerWorkGroup": {
    "id": 23
  }
}
```

#### II. DatePostViewModel

> Принимаемая модель конкретной даты, либо диапазона в формате Unixtimestamp, для выполнения фильтрации по определенному полю.

#### Приоритет обработки полей _(если решились заполнить несколько полей модели)_: 
#### _equals -> range -> lessThan -> moreThan_ 

> **Замечание:** на данный момент обработчик модели реализовать только для _Monq.ClickHouse.Client_ - метод FilterExtensions.FilterByDateRange(string fieldName, DatePostViewModel date) - используются в связке с _SQL Query Builder_.


##### Пример:

```CSharp
/// <summary>
/// Модель фильтра сборок ФТ.
/// </summary>
public class BuildFilterViewModel
{
   /// <summary>
   /// Время начала выполнения.
   /// </summary>
   public virtual DatePostViewModel DateStart { get; set; } = null;

   /// <summary>
   /// Время окончания выполнения.
   /// </summary>
   public virtual DatePostViewModel DateEnd { get; set; } = null;

   ...
}
```

```JS
{
    "DateStart": {
        "Equal": 1564606800
    },
    "DateEnd": {
        "range": {
            "start": 1564606800,
            "end": 1565643599
        }
    }
}
```

## Аттрибуты валидации

#### I. BasicIdRequiredAttribute

> Модификация _RequiredAttribute_ для типа _BasicIdPostViewModel_.

##### Пример:

```CSharp
/// <summary>
/// Принимаемая модель для создания синтетического триггера.
/// </summary>
public class GateSyntheticTriggerPostViewModel
{
    /// <summary>
    /// Рабочая группа-владелец.
    /// </summary>
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### II. BasicIdRangeAttribute

> Модификация _RangeAttribute_ для типа _BasicIdPostViewModel_.

##### Пример:

```CSharp
/// <summary>
/// Принимаемая модель для создания синтетического триггера.
/// </summary>
public class GateSyntheticTriggerPostViewModel
{
    /// <summary>
    /// Рабочая группа-владелец.
    /// </summary>
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### II. StringRangeAttribute

> Атрибут для валидации возможных значений строкового типа.

##### Пример:

```CSharp
/// <summary>
/// Принимаемая модель представления, которая включает в себя модели представления предоставления общего доступа к сущности
/// для моделей POST/PUT/PATCH.
/// </summary>
public abstract class SharedEntityPostViewModel
{
    /// <summary>
    /// Модель представления общих прав всем РГ.
    /// </summary>
    [StringRange("read", "basic-read", "write")]
    public IEnumerable<string> SharedToAll { get; set; } = Enumerable.Empty<string>();

    ...
}
```