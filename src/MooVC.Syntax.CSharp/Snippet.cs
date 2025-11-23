namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Immutable;
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

        public bool IsEmpty => this == Empty;

        public bool IsSingleLine => !_value.IsDefaultOrEmpty && _value.Length == SingleLine;

        public static Snippet From(string value)
        {
            return From(value, Options.Default);
        }

        public static Snippet From(string value, Options options)
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

        public Snippet Block(Options options)
        {
            _ = Guard.Against.Null(options, message: BlockOptionsRequired);

            const int MaximumAdditionalLinesRequiredForBlock = 2;

            string[] blocked = new string[_value.Length + MaximumAdditionalLinesRequiredForBlock];
            int index = 0;

            blocked[index] = _value[index];

            if (options.Block.Style == BlockOptions.StyleType.KAndR)
            {
                blocked[index] = string.Concat(_value[index], $" {options.Block.Markers.Opening}");
            }
            else
            {
                blocked[++index] = options.Block.Markers.Opening;
            }

            for (int line = 1; line < _value.Length; line++)
            {
                blocked[++index] = string.Concat(options.Whitespace, _value[line]);
            }

            blocked[++index] = options.Block.Markers.Closing;

            return new Snippet(ImmutableArray.Create(blocked, 0, index + 1));
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

        public override string ToString()
        {
            return ToString(Options.Default);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired);

            return string.Join(options.NewLine, _value);
        }
    }
}