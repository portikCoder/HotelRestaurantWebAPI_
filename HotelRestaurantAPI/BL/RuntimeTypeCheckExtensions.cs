using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.BL
{
    public static class RuntimeTypeCheckExtensions
    {
        public static bool IsAssignableToAnyOf(this Type typeOperand, IEnumerable<Type> types)
        {
            return types.Any(type => type.IsAssignableFrom(typeOperand));
        }

        public static bool IsAssignableToAnyOf(this Type typeOperand, params Type[] types)
        {
            return IsAssignableToAnyOf(typeOperand, types.AsEnumerable());
        }

        public static bool IsAssignableToAnyOf<T1, T2, T3>(this Type typeOperand)
        {
            return typeOperand.IsAssignableToAnyOf(typeof(T1), typeof(T2), typeof(T3));
        }

        public static bool IsAssignableToAnyOf<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(this Type typeOperand)
        {
            return typeOperand.IsAssignableToAnyOf(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16), typeof(T17), typeof(T18), typeof(T19), typeof(T20));
        }
    }

}