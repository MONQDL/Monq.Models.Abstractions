using System;

namespace Monq.Models.Abstractions.Extensions
{
    public static class DatePostViewModelExtensions
    {
        /// <summary>
        /// Convert value to <see cref="v2.DatePostViewModel"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static v2.DatePostViewModel ToV2Model(this DatePostViewModel value) =>
            new v2.DatePostViewModel
            {
                Equal = TryConvertToDateTime(value.Equal),
                LessThan = TryConvertToDateTime(value.LessThan),
                LessThanOrEqual = TryConvertToDateTime(value.LessThanOrEqual),
                MoreThan = TryConvertToDateTime(value.MoreThan),
                MoreThanOrEqual = TryConvertToDateTime(value.MoreThanOrEqual),
                Range = value.Range != null ? new v2.DateRangePostViewModel
                {
                    Start = TryConvertToDateTime(value.Range.Start)!.Value,
                    End = TryConvertToDateTime(value.Range.End)!.Value,
                } : null
            };

        /// <summary>
        /// Convert value to <see cref="v2.DatePostViewModel"/> using DateTimeOffset.FromUnixTimeMilliseconds converter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static v2.DatePostViewModel ToV2ModelFromMilliseconds(this DatePostViewModel value) =>
            new v2.DatePostViewModel
            {
                Equal = ConvertToDateTimeFromMilliseconds(value.Equal),
                LessThan = ConvertToDateTimeFromMilliseconds(value.LessThan),
                LessThanOrEqual = ConvertToDateTimeFromMilliseconds(value.LessThanOrEqual),
                MoreThan = ConvertToDateTimeFromMilliseconds(value.MoreThan),
                MoreThanOrEqual = ConvertToDateTimeFromMilliseconds(value.MoreThanOrEqual),
                Range = value.Range != null ? new v2.DateRangePostViewModel
                {
                    Start = ConvertToDateTimeFromMilliseconds(value.Range.Start)!.Value,
                    End = ConvertToDateTimeFromMilliseconds(value.Range.End)!.Value,
                } : null
            };

        /// <summary>
        /// Convert value to <see cref="v2.DatePostViewModel"/> using DateTimeOffset.FromUnixTimeSeconds converter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static v2.DatePostViewModel ToV2ModelFromSeconds(this DatePostViewModel value) =>
            new v2.DatePostViewModel
            {
                Equal = ConvertToDateTimeFromSeconds(value.Equal),
                LessThan = ConvertToDateTimeFromSeconds(value.LessThan),
                LessThanOrEqual = ConvertToDateTimeFromSeconds(value.LessThanOrEqual),
                MoreThan = ConvertToDateTimeFromSeconds(value.MoreThan),
                MoreThanOrEqual = ConvertToDateTimeFromSeconds(value.MoreThanOrEqual),
                Range = value.Range != null ? new v2.DateRangePostViewModel
                {
                    Start = ConvertToDateTimeFromSeconds(value.Range.Start)!.Value,
                    End = ConvertToDateTimeFromSeconds(value.Range.End)!.Value,
                } : null
            };

        static DateTimeOffset? TryConvertToDateTime(long? value)
        {
            if (value is null)
                return null;
            DateTimeOffset result;
            // Is looks very hacky.
            try
            {
                result = DateTimeOffset.FromUnixTimeSeconds(value.Value);
            }
            catch (Exception)
            {
                result = DateTimeOffset.FromUnixTimeMilliseconds(value.Value);
            }
            return result;
        }

        static DateTimeOffset? ConvertToDateTimeFromMilliseconds(long? value)
        {
            if (value is null)
                return null;
            return DateTimeOffset.FromUnixTimeMilliseconds(value.Value);
        }

        static DateTimeOffset? ConvertToDateTimeFromSeconds(long? value)
        {
            if (value is null)
                return null;
            return DateTimeOffset.FromUnixTimeSeconds(value.Value);
        }
    }
}
