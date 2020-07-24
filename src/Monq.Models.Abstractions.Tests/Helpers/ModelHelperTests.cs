using System;
using Monq.Models.Abstractions.Helpers;
using Xunit;

namespace Monq.Models.Abstractions.Tests.Helpers
{
    public class ModelHelperTests
    {
        [Theory(DisplayName = "Проверка перезаписи значения строкового типа.")]
        [InlineData(sbyte.MaxValue)]
        [InlineData(byte.MaxValue)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        public void ShouldProperlyOverrideStringValue(int seed)
        {
            var sporadic = new Random(seed);

            var initialStr = sporadic.GetRandomName();
            var putModel = new ModelPropertyPutViewModel
            {
                Value = sporadic.GetRandomName(),
                Behavior = ModelPropertyPutBehavior.Override
            };

            var updatedStr = ModelHelper.Update(initialStr, putModel);

            Assert.Equal(putModel.Value, updatedStr);
        }

        [Theory(DisplayName = "Проверка конкатенации старого и нового значения строкового типа.")]
        [InlineData(sbyte.MaxValue)]
        [InlineData(byte.MaxValue)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        public void ShouldProperlyAppendStringValue(int seed)
        {
            var sporadic = new Random(seed);

            var initialStr = sporadic.GetRandomName();
            var putModel = new ModelPropertyPutViewModel
            {
                Value = sporadic.GetRandomName(),
                Behavior = ModelPropertyPutBehavior.Append
            };

            var updatedStr = ModelHelper.Update(initialStr, putModel);

            Assert.Equal(initialStr + putModel.Value, updatedStr);
        }

        [Fact(DisplayName = "Проверка наличия подстроки по новому значению, если в модели указан флаг проверки.")]
        public void ShouldProperlyCheckExistingSubstring()
        {
            var initialStr = "___test___";
            var putModel = new ModelPropertyPutViewModel
            {
                Value = "test",
                CheckExistingSubstring = true,
                Behavior = ModelPropertyPutBehavior.Append
            };

            var updatedStr = ModelHelper.Update(initialStr, putModel);

            Assert.Equal(initialStr, updatedStr);
        }
    }
}