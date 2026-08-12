using System;

namespace Callvote.API.Features.Extensions;

/// <summary>
/// Represents the class for math Extensions.
/// </summary>
public static class MathExtension
{
    /// <summary>
    /// Clamps a number between two values.
    /// </summary>
    /// <param name="val">The value to be compared to.</param>
    /// <param name="min">The minimum value to be compared to.</param>
    /// <param name="max">The maximum value to be compared to.</param>
    /// <typeparam name="T">An IComparable value.</typeparam>
    /// <returns>The clamped value.</returns>
    public static T Clamp<T>(this T val, T min, T max)
        where T : IComparable<T>
    {
        if (val.CompareTo(min) < 0)
        {
            return min;
        }
        else if (val.CompareTo(max) > 0)
        {
            return max;
        }
        else
        {
            return val;
        }
    }
}