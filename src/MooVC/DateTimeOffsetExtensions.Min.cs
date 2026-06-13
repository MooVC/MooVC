namespace MooVC
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides the Min extension for <see cref="DateTimeOffset" />.
    /// </summary>
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Returns the earlier of two <see cref="DateTimeOffset" /> values.
        /// </summary>
        /// <param name="first">The first date to compare.</param>
        /// <param name="second">The second date to compare.</param>
        /// <returns>The earlier of the two dates.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Min(this DateTimeOffset first, DateTimeOffset second)
        {
            return first.Ticks > second.Ticks
                ? second
                : first;
        }
    }
}