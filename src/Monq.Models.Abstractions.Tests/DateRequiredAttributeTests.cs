using Xunit;
using System;
using System.Collections.Generic;
using Monq.Models.Abstractions.DataAnnotations;

namespace Monq.Models.Abstractions.Tests
{
    public class DateRequiredAttributeTests
    {
        [Theory(DisplayName = "Проверка валидации DatePostViewModel - простые поля.")]
        [MemberData(nameof(ShouldProperlyValidateDateModelWithSimpleValueData))]
        public void ShouldProperlyValidateDateModelWithSimpleValue(DatePostViewModel model)
        {
            var attribute = new DateRequiredAttribute();
            var result = attribute.IsValid(model);
            Assert.True(result);
        }

        [Fact(DisplayName = "Проверка валидации DatePostViewModel - диапазон дат.")]
        public void ShouldProperlyValidateDateModelWithRange()
        {
            var attribute = new DateRequiredAttribute();
            var model = new DatePostViewModel
            {
                Range = new DateRangePostViewModel
                {
                    Start = DateTimeOffset.Now.AddDays(-2).ToUnixTimeSeconds(),
                    End = DateTimeOffset.Now.ToUnixTimeSeconds()
                }
            };

            var result = attribute.IsValid(model);

            Assert.True(result);
        }

        [Fact(DisplayName = "Проверка валидации DatePostViewModel - пустая модель.")]
        public void ShouldProperlyValidateEmptyModel()
        {
            var attribute = new DateRequiredAttribute();
            var model = new DatePostViewModel();

            var result = attribute.IsValid(model);

            Assert.False(result);
        }

        [Fact(DisplayName = "Проверка валидации DatePostViewModel - не указаны все поля в диапазоне.", 
            Skip = "Следует сделать nullable поля в DateRangePostViewModel и обновить другие библиотеки, где это используется.")]
        public void ShouldProperlyValidateWrongRangeModel()
        {
            var attribute = new DateRequiredAttribute();
            var model = new DatePostViewModel
            {
                Range = new DateRangePostViewModel
                {
                    Start = DateTimeOffset.Now.AddDays(-2).ToUnixTimeSeconds()
                }
            };

            var result = attribute.IsValid(model);

            Assert.False(result);
        }

        static IEnumerable<object[]> ShouldProperlyValidateDateModelWithSimpleValueData() =>
            new[]
            {
                new[]
                {
                    new DatePostViewModel { Equal = DateTimeOffset.Now.ToUnixTimeSeconds() }
                },
                new[]
                {
                    new DatePostViewModel { LessThan = DateTimeOffset.Now.ToUnixTimeSeconds() }
                },
                new[]
                {
                    new DatePostViewModel { LessThanOrEqual = DateTimeOffset.Now.ToUnixTimeSeconds() }
                },
                new[]
                {
                    new DatePostViewModel { MoreThan = DateTimeOffset.Now.ToUnixTimeSeconds() }
                },
                new[]
                {
                    new DatePostViewModel { MoreThanOrEqual = DateTimeOffset.Now.ToUnixTimeSeconds() }
                },
            };
    }
}