namespace MooVC.Syntax.Elements
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.Elements.Snippet_Resources;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    [Monify(Type = typeof(ImmutableArray<string>))]
    [SkipAutoInitialization]
    public sealed partial class Snippet
        : IValidatableObject
    {
        /// <summary>
        /// Represents the blank for the Snippet.
        /// </summary>
        public static readonly Snippet Blank = new Snippet(Options.Default, new string[] { string.Empty }.ToImmutableArray());

        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Snippet Empty = new Snippet(Options.Default, ImmutableArray<string>.Empty);

        private const int SingleLine = 1;
        private readonly Options _options;

        /// <summary>
        /// Initializes a new instance of the Snippet class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal Snippet(ImmutableArray<string> value)
            : this(Options.Default, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Snippet class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="value">The value.</param>
        internal Snippet(Options options, ImmutableArray<string> value)
        {
            _ = Guard.Against.Null(options, message: FromOptionsRequired.Format(nameof(Options), nameof(value)));

            if (value.IsDefault)
            {
                value = ImmutableArray<string>.Empty;
            }

            _options = options;
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the Snippet is empty.
        /// </summary>
        /// <value>A value indicating whether the Snippet is empty.</value>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets a value indicating whether the Snippet is multi line.
        /// </summary>
        /// <value>A value indicating whether the Snippet is multi line.</value>
        public bool IsMultiLine => !_value.IsDefaultOrEmpty && Lines > SingleLine;

        /// <summary>
        /// Gets a value indicating whether the Snippet is single line.
        /// </summary>
        /// <value>A value indicating whether the Snippet is single line.</value>
        public bool IsSingleLine => !_value.IsDefaultOrEmpty && Lines == SingleLine;

        /// <summary>
        /// Gets the lines on the Snippet.
        /// </summary>
        /// <value>The lines.</value>
        public int Lines => _value.IsDefaultOrEmpty ? 0 : _value.Length;

        /// <summary>
        /// Defines the Snippet operator for the Snippet.
        /// </summary>
        /// <param name="snippet">The snippet.</param>
        /// <returns>The snippet instance.</returns>
        public static implicit operator Snippet(string snippet)
        {
            Guard.Against.Conversion<string, Snippet>(snippet);

            return From(snippet);
        }

        /// <summary>
        /// Defines the string operator for the Snippet.
        /// </summary>
        /// <param name="snippet">The snippet.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Snippet snippet)
        {
            Guard.Against.Conversion<Snippet, string>(snippet);

            return snippet.ToString();
        }

        /// <summary>
        /// Performs the from operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public static Snippet From(params string[] values)
        {
            return From(Options.Default, values);
        }

        /// <summary>
        /// Performs the from operation for the syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public static Snippet From(Options options, params string[] values)
        {
            _ = Guard.Against.Null(options, message: FromOptionsRequired.Format(nameof(Options), nameof(values)));
            _ = Guard.Against.Null(values, message: FromValueRequired.Format(nameof(values)));

            if (values.Length == 0 || (values.Length == 1 && string.IsNullOrEmpty(values[0])))
            {
                return new Snippet(options, ImmutableArray<string>.Empty);
            }

            ImmutableArray<string>.Builder builder = ImmutableArray.CreateBuilder<string>(values.Length);

            foreach (string value in values)
            {
                string[] lines = value.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    builder.Add(line);
                }
            }

            return new Snippet(options, builder.ToImmutable());
        }

        /// <summary>
        /// Performs the append operation for the syntax element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The snippet.</returns>
        public Snippet Append(char value)
        {
            if (IsEmpty)
            {
                return From(value.ToString());
            }

            ImmutableArray<string>.Builder builder = ImmutableArray.CreateBuilder<string>();
            int last = Lines - 1;

            for (int index = 0; index < last; index++)
            {
                builder.Add(_value[index]);
            }

            builder.Add(string.Concat(_value[last], value));

            return new Snippet(_options, builder.ToImmutable());
        }

        /// <summary>
        /// Performs the append operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public Snippet Append(params string[] values)
        {
            return Combine(_options, _value, values, (original, appended) => original.Concat(appended));
        }

        /// <summary>
        /// Performs the append operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public Snippet Append(params Snippet[] values)
        {
            return Combine(_value, values, (original, appended) => original.Concat(appended));
        }

        /// <summary>
        /// Performs the block operation for the syntax element.
        /// </summary>
        /// <returns>The snippet.</returns>
        public Snippet Block()
        {
            return Block(Empty);
        }

        /// <summary>
        /// Performs the block operation for the syntax element.
        /// </summary>
        /// <param name="opening">The opening.</param>
        /// <returns>The snippet.</returns>
        public Snippet Block(Snippet opening)
        {
            _ = Guard.Against.Null(opening, message: BlockOpeningRequired);

            Options options = _options;

            const int MaximumAdditionalLinesRequiredForBlock = 2;

            int openingLines = opening.Lines;
            string[] blocked = ArrayPool<string>.Shared.Rent(Lines + openingLines + MaximumAdditionalLinesRequiredForBlock);

            try
            {
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

                    return new Snippet(options, ImmutableArray.Create(blocked, 0, index));
                }

                if (options.Block.Style.IsKAndR && openingLines > 0)
                {
                    blocked[index - 1] = string.Concat(blocked[index - 1], $" {options.Block.Markers.Opening}");
                }
                else
                {
                    blocked[index++] = options.Block.Markers.Opening;
                }

                string whitespace = options.Whitespace;

                for (int line = 0; line < Lines; line++)
                {
                    string current = _value[line];

                    if (!string.IsNullOrEmpty(current))
                    {
                        current = string.Concat(whitespace, _value[line]);
                    }

                    blocked[index++] = current;
                }

                blocked[index] = options.Block.Markers.Closing;

                return new Snippet(options, ImmutableArray.Create(blocked, 0, index + 1));
            }
            finally
            {
                ArrayPool<string>.Shared.Return(blocked);
            }
        }

        /// <summary>
        /// Performs the combine operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public Snippet Combine(params Snippet[] values)
        {
            _ = Guard.Against.Null(values, message: CombineSnippetsRequired);

            values = StripEmptySnippets(values);

            if (values.Length == 0)
            {
                return new Snippet(_options, ImmutableArray<string>.Empty);
            }

            if (values.Length == 1)
            {
                return values[0];
            }

            string[] combined = AllocateWorkingMemoryForCombine(values);

            return Combine(combined, values);
        }

        /// <summary>
        /// Performs the prepend operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public Snippet Prepend(params string[] values)
        {
            return Combine(_options, _value, values, (original, prepended) => prepended.Concat(original));
        }

        /// <summary>
        /// Performs the prepend operation for the syntax element.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The snippet.</returns>
        public Snippet Prepend(params Snippet[] values)
        {
            return Combine(_value, values, (original, prepended) => prepended.Concat(original));
        }

        /// <summary>
        /// Performs the shift operation for the syntax element.
        /// </summary>
        /// <returns>The snippet.</returns>
        public Snippet Shift()
        {
            Options options = _options;

            string[] shifted = ArrayPool<string>.Shared.Rent(Lines);

            try
            {
                string whitespace = options.Whitespace;

                for (int index = 0; index < Lines; index++)
                {
                    string current = _value[index];

                    if (!string.IsNullOrEmpty(current))
                    {
                        current = string.Concat(whitespace, _value[index]);
                    }

                    shifted[index] = current;
                }

                return new Snippet(options, ImmutableArray.Create(shifted, 0, Lines));
            }
            finally
            {
                ArrayPool<string>.Shared.Return(shifted);
            }
        }

        /// <summary>
        /// Performs the stack operation for the syntax element.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>The snippet.</returns>
        public Snippet Stack(Snippet top)
        {
            _ = Guard.Against.Null(top, message: StackTopRequired.Format(nameof(Snippet), nameof(Stack)));

            return Prepend(top);
        }

        /// <summary>
        /// Returns the string representation of the Snippet.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (Lines == 0)
            {
                return string.Empty;
            }

            if (Lines == 1)
            {
                return _value[0];
            }

            var builder = new StringBuilder();
            int last = Lines - 1;

            for (int index = 0; index < last; index++)
            {
                builder = builder.AppendLine(_value[index]);
            }

            builder = builder.Append(_value[last]);

            return builder.ToString();
        }

        /// <summary>
        /// Validates the Snippet.
        /// </summary>
        /// <remarks>Required members include: Lines.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext.Items.TryGetValue(nameof(Lines), out object value)
             && value is int lines
             && Lines != lines)
            {
                yield return new ValidationResult(ValidateLinesMismatch.Format(nameof(Lines), Lines, lines), new[] { nameof(Lines) });
            }
        }

        private static void Combine(string[] combined, ref int index, Snippet snippet)
        {
            for (int line = 0; line < snippet.Lines; line++)
            {
                combined[index++] = snippet._value[line];
            }
        }

        private static Snippet Combine(
            Options options,
            Snippet original,
            string[] values,
            Func<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> combine)
        {
            Snippet[] snippets = ArrayPool<Snippet>.Shared.Rent(values.Length);

            try
            {
                for (int index = 0; index < values.Length; index++)
                {
                    snippets[index] = From(options, values[index]);
                }

                return Combine(options, original, snippets.Take(values.Length), combine);
            }
            finally
            {
                ArrayPool<Snippet>.Shared.Return(snippets);
            }
        }

        private static Snippet Combine(
            Options options,
            Snippet original,
            IEnumerable<Snippet> values,
            Func<IEnumerable<string>, IEnumerable<string>, IEnumerable<string>> combine)
        {
            IEnumerable<string> first = original._value.Select(value => value);
            IEnumerable<string> second = values.SelectMany(snippet => snippet._value.Select(value => value));

            return new Snippet(options, combine(first, second).ToImmutableArray());
        }

        private static Snippet[] StripEmptySnippets(Snippet[] values)
        {
            return values
                .Where(snippet => !snippet.IsEmpty)
                .ToArray();
        }

        private string[] AllocateWorkingMemoryForCombine(Snippet[] values)
        {
            int separators = (values.Length - 1) * Lines;
            int length = values.Sum(snippet => snippet.Lines) + separators;
            string[] combined = ArrayPool<string>.Shared.Rent(length);

            return combined;
        }

        private Snippet Combine(string[] combined, Snippet[] values)
        {
            try
            {
                int index = 0;
                int last = values.Length - 1;

                for (int current = 0; current < values.Length; current++)
                {
                    Snippet snippet = values[current];

                    if (snippet.IsEmpty)
                    {
                        continue;
                    }

                    Combine(combined, ref index, snippet);

                    if (current != last)
                    {
                        Combine(combined, ref index, this);
                    }
                }

                return new Snippet(_options, combined
                    .Take(index)
                    .ToImmutableArray());
            }
            finally
            {
                ArrayPool<string>.Shared.Return(combined);
            }
        }
    }
}
