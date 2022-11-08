using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Domain.Guards
{
    public static class CustomGuards
    {
        public static DateTimeOffset OutOfRange(this IGuardClause guardClause, DateTimeOffset input, string parameterName, DateTimeOffset rangeFrom, DateTimeOffset rangeTo)
        {
            return OutOfRange<DateTimeOffset>(guardClause, input, parameterName, rangeFrom, rangeTo);
        }

        private static T OutOfRange<T>(this IGuardClause guardClause, T input, string parameterName, T rangeFrom, T rangeTo)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            if(comparer.Compare(rangeFrom, rangeTo) > 0)
            {
                throw new ArgumentException($"{nameof(rangeFrom)} should be less than or equal {nameof(rangeTo)}");
            }

            if(comparer.Compare(rangeFrom, rangeTo) < 0 || comparer.Compare(input, rangeTo) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Input {parameterName} was out of range");
            }

            return input;
        }
    }
}
