namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax event extensions.
    /// </summary>
    public static partial class EventExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="events">The events.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Event> events, Snippet.Options options)
        {
            if (events.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = events
                .OrderByDescending(@event => @event.Scope)
                .ThenBy(@event => @event.Name)
                .Select(@event => @event.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}