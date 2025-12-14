namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class EventExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Event> events, Snippet.Options options)
        {
            if (events.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = events
                .OrderBy(@event => @event)
                .Select(@event => @event.ToString(options))
                .ToArray();

            return options.BlankSpace.Combine(options, content);
        }
    }
}