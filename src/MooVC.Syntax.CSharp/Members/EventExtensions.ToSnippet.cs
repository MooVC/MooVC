namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax event extensions.
    /// </summary>
    public static partial class EventExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
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