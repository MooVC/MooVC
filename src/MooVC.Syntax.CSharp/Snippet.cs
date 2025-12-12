namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.CSharp.Snippet_Resources;

    [Monify(Type = typeof(ImmutableArray<string>))]
    [SkipAutoInstantiation]
    public sealed partial class Snippet
    {
        public static readonly Snippet Empty = new Snippet(ImmutableArray<string>.Empty);
        private const int SingleLine = 1;
        private const string Separator = " ";

        public bool IsEmpty => this == Empty;

        public bool IsMultiLine => !_value.IsDefaultOrEmpty && _value.Length > SingleLine;

        public bool IsSingleLine => !_value.IsDefaultOrEmpty && _value.Length == SingleLine;

        public int Lines => _value.Length;

        public static implicit operator string(Snippet snippet)
        {
            Guard.Against.Conversion<Snippet, string>(snippet);

            return snippet.ToString();
        }

        public static Snippet From(string value)
        {
            return From(Options.Default, value);
        }

        public static Snippet From(Options options, string value)
        {
            _ = Guard.Against.Null(options, message: FromOptionsRequired.Format(nameof(Options), nameof(value)));
            _ = Guard.Against.Null(value, message: FromValueRequired.Format(nameof(value)));

            if (string.IsNullOrWhiteSpace(value))
            {
                return Empty;
            }

            string[] lines = value.Split(new[] { options.NewLine }, StringSplitOptions.None);

            return new Snippet(ImmutableArray.Create(lines));
        }

        public Snippet Append(char value)
        {
            ImmutableArray<string>.Builder builder = ImmutableArray.CreateBuilder<string>();
            int last = _value.Length - 1;

            for (int index = 0; index < last; index++)
            {
                builder.Add(_value[index]);
            }

            builder.Add(string.Concat(_value[last], value));

            return builder.ToImmutable();
        }

        public Snippet Append(params string[] values)
        {
            return Append(Options.Default, values);
        }

        public Snippet Append(Options options, params string[] values)
        {
            return Combine(options, _value, values, (original, appended) => original.Concat(appended));
        }

        public Snippet Append(params Snippet[] values)
        {
            return Combine(_value, values, (original, appended) => original.Concat(appended));
        }

        public Snippet Block(Options options)
        {
            return Block(options, Empty);
        }

        public Snippet Block(Options options, Snippet opening)
        {
            _ = Guard.Against.Null(options, message: BlockOptionsRequired);
            _ = Guard.Against.Null(options, message: BlockOpeningRequired);

            const int MaximumAdditionalLinesRequiredForBlock = 2;

            int openingLines = opening.Lines;
            string[] blocked = new string[_value.Length + openingLines + MaximumAdditionalLinesRequiredForBlock];
            int index = 0;

            for (; index < openingLines; index++)
            {
                blocked[index] = opening._value[index];
            }

            if (IsSingleLine && !options.Block.Inline.IsMultiLineBraces)
            {
                if (options.Block.Inline.IsLambda)
                {
                    blocked[index - 1] = string.Concat(blocked[index - 1], $" => {_value[0]}");
                }
                else if (options.Block.Inline.IsSingleLineBraces)
                {
                    blocked[index - 1] = string.Concat(blocked[index - 1], $" {options.Block.Markers.Opening} {_value[0]} {options.Block.Markers.Closing}");
                }

                return new Snippet(ImmutableArray.Create(blocked, 0, index));
            }

            if (options.Block.Style.IsKAndR && openingLines > 0)
            {
                blocked[index - 1] = string.Concat(blocked[index - 1], $" {options.Block.Markers.Opening}");
            }
            else
            {
                blocked[index++] = options.Block.Markers.Opening;
            }

            for (int line = 0; line < _value.Length; line++)
            {
                blocked[index++] = string.Concat(options.Whitespace, _value[line]);
            }

            blocked[index] = options.Block.Markers.Closing;

            return new Snippet(ImmutableArray.Create(blocked, 0, index + 1));
        }

        public Snippet Prepend(params string[] values)
        {
            return Prepend(Options.Default, values);
        }

        public Snippet Prepend(Options options, params string[] values)
        {
            return Combine(options, _value, values, (original, prepended) => prepended.Concat(original));
        }

        public Snippet Prepend(params Snippet[] values)
        {
            return Combine(_value, values, (original, prepended) => prepended.Concat(original));
        }

        public Snippet Shift(Options options)
        {
            _ = Guard.Against.Null(options, message: ShiftOptionsRequired);

            string[] shifted = new string[_value.Length];

            for (int index = 0; index < _value.Length; index++)
            {
                shifted[index] = string.Concat(options.Whitespace, _value[index]);
            }

            return new Snippet(ImmutableArray.Create(shifted));
        }

        public Snippet Stack(Options options, Snippet top)
        {
            _ = Guard.Against.Null(options, message: StackOptionsRequired);
            _ = Guard.Against.Null(top, message: StackTopRequired.Format(nameof(Snippet), nameof(Stack)));

            string separator = IsSingleLine && top.IsSingleLine
                ? options.NewLine
                : Separator;

            return Prepend(options, separator)
                .Prepend(options, top);
        }

        public override string ToString()
        {
            return ToString(Options.Default);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired);

            return string.Join(options.NewLine, _value);
        }

        private static ImmutableArray<string> Combine(
            Options options,
            Snippet original,
            string[] values,
            Func<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> combine)
        {
            var snippets = new Snippet[values.Length];

            for (int index = 0; index < values.Length; index++)
            {
                snippets[index] = From(options, values[index]);
            }

            return Combine(original, snippets, combine);
        }

        private static ImmutableArray<string> Combine(
            Snippet original,
            Snippet[] values,
            Func<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> combine)
        {
            IEnumerable<string> first = original._value.Select(value => value);
            IEnumerable<string> second = values.SelectMany(snippet => snippet._value.Select(value => value));

            return combine(first, second).ToImmutableArray();
        }
    }
}