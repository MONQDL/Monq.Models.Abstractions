# Monq.Models.Abstractions

*English*

The library provides input model primitives, as well as custom validation attributes.

## Installation

```powershell
Install-Package Monq.Models.Abstractions
```

## Модели

#### I. BasicIdPostViewModel

> The data model is used in requests for data binding among themselves when adding and updating objects.

##### Example:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Owning workgroup ID was not specified.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Invalid value for owner workgroup ID.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }

    ...
}
```

```json
{
  "ownerWorkGroup": {
    "id": 23
  }
}
```

#### II. DatePostViewModel

> The accepted model for a specific date, or range, in Unixtimestamp format, to filter on a specific field.

> There is also a version of the model that works with DateTimeOffset - located in the _Monq.Models.Abstractions.v2_ namespace

#### Priority of processing fields _(if you decided to fill in several fields of the model)_:
#### _equals -> range -> LessThanOrEqual -> MoreThanOrEqual -> lessThan -> moreThan_ 

#### Combinations are allowed:
    1. LessThanOrEqual && MoreThanOrEqual: >= x <=
    2. LessThan && MoreThan: > x <
    3. LessThanOrEqual && MoreThan: >= x <
    4. LessThan && MoreThanOrEqual: > x <=

> **Note:** at the moment the model handler is implemented only for _Monq.ClickHouse.Client_ - the FilterExtensions.FilterByDateRange method (string fieldName, DatePostViewModel date) - are used in conjunction with _SQL Query Builder_.

##### Example:

```csharp
public class BuildFilterViewModel
{
   public virtual DatePostViewModel DateStart { get; set; } = null;

   public virtual DatePostViewModel DateEnd { get; set; } = null;

   ...
}
```

```json
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

## Validation Attributes

#### I. BasicIdRequiredAttribute

> Modification of _RequiredAttribute_ for type _BasicIdPostViewModel_.

##### Example:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Owning workgroup ID was not specified.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Invalid value for owner workgroup ID.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### II. BasicIdRangeAttribute

> Modification of _RangeAttribute_ for type _BasicIdPostViewModel_.

##### Example:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Owning workgroup ID was not specified.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Invalid value for owner workgroup ID.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### III. StringRangeAttribute

> Attribute for validating possible values of a string type.

##### Example:

```csharp
public abstract class SharedEntityPostViewModel
{
    [StringRange("read", "basic-read", "write")]
    public IEnumerable<string> SharedToAll { get; set; } = Enumerable.Empty<string>();

    ...
}
```

#### IV. NotEmptyAttribute

> Modification of _RequiredAttribute_ for a collection of type _IEnumerable_.

##### Example:

```csharp
public class GateAutomatonRulePutViewModel
{
    ...

    [NotEmpty(ErrorMessage = "The list of input variables of the rule script is not specified.")]
    public IEnumerable<GateAutomatonRuleVariablePostViewModel> Variables { get; set; } = Enumerable.Empty<GateAutomatonRuleVariablePostViewModel>();
}
```

#### V. DateRequiredAttribute

> Modification of _RequiredAttribute_ for type _DateRangePostViewModel_.

##### Example:

```csharp
public class GateSTEventHistoryFilterViewModel
{
    [DateRequired(ErrorMessage = "The start date of the event was not specified.")]
    public DatePostViewModel DateStart { get; set; } = null;

    [DateRequired(ErrorMessage = "The end date of the event was not specified.")]
    public DatePostViewModel DateEnd { get; set; } = null;
}
```

*Русский*

В библиотеке представлены примитивы входных моделей, а также кастомные атрибуты валидации.

## Установка

```powershell
Install-Package Monq.Models.Abstractions
```

## Модели

#### I. BasicIdPostViewModel

> Модель данных используется в запросах на привязку данных между собой при добавлении и обновлении объектов. 

##### Пример:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }

    ...
}
```

```json
{
  "ownerWorkGroup": {
    "id": 23
  }
}
```

#### II. DatePostViewModel

> Принимаемая модель конкретной даты, либо диапазона в формате Unixtimestamp, для выполнения фильтрации по определенному полю.

> Существует также версия модели, которая работает с DateTimeOffset - находится в пространстве имен _Monq.Models.Abstractions.v2_

#### Приоритет обработки полей _(если решились заполнить несколько полей модели)_: 
#### _equals -> range -> LessThanOrEqual -> MoreThanOrEqual -> lessThan -> moreThan_ 

#### Допускаются комбинации: 
    1. LessThanOrEqual && MoreThanOrEqual: >= x <=
    2. LessThan && MoreThan: > x <
    3. LessThanOrEqual && MoreThan: >= x <
    4. LessThan && MoreThanOrEqual: > x <=

> **Замечание:** на данный момент обработчик модели реализовать только для _Monq.ClickHouse.Client_ - метод FilterExtensions.FilterByDateRange(string fieldName, DatePostViewModel date) - используются в связке с _SQL Query Builder_.

##### Пример:

```csharp
public class BuildFilterViewModel
{
   public virtual DatePostViewModel DateStart { get; set; } = null;

   public virtual DatePostViewModel DateEnd { get; set; } = null;

   ...
}
```

```json
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

## Атрибуты валидации

#### I. BasicIdRequiredAttribute

> Модификация _RequiredAttribute_ для типа _BasicIdPostViewModel_.

##### Пример:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### II. BasicIdRangeAttribute

> Модификация _RangeAttribute_ для типа _BasicIdPostViewModel_.

##### Пример:

```csharp
public class GateSyntheticTriggerPostViewModel
{
    [BasicIdRequired(ErrorMessage = "Не указан идентификатор рабочей группы-владельца.")]
    [BasicIdRange(1, long.MaxValue, ErrorMessage = "Недопустимое значение идентификатора рабочей группы-владельца.")]
    public BasicIdPostViewModel OwnerWorkGroup { get; set; }
}
```

#### III. StringRangeAttribute

> Атрибут для валидации возможных значений строкового типа.

##### Пример:

```csharp
public abstract class SharedEntityPostViewModel
{
    [StringRange("read", "basic-read", "write")]
    public IEnumerable<string> SharedToAll { get; set; } = Enumerable.Empty<string>();

    ...
}
```

#### IV. NotEmptyAttribute

> Модификация _RequiredAttribute_ для коллекции типа _IEnumerable_.

##### Пример:

```csharp
public class GateAutomatonRulePutViewModel
{
    ...

    [NotEmpty(ErrorMessage = "Не указан список входных переменных скрипта правила.")]
    public IEnumerable<GateAutomatonRuleVariablePostViewModel> Variables { get; set; } = Enumerable.Empty<GateAutomatonRuleVariablePostViewModel>();
}
```

#### V. DateRequiredAttribute

> Модификация _RequiredAttribute_ для типа _DateRangePostViewModel_.

##### Пример:

```csharp
public class GateSTEventHistoryFilterViewModel
{
    [DateRequired(ErrorMessage = "Не указана дата начала события.")]
    public DatePostViewModel DateStart { get; set; } = null;

    [DateRequired(ErrorMessage = "Не указана дата окончания события.")]
    public DatePostViewModel DateEnd { get; set; } = null;
}
```