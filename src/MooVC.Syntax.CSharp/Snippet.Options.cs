namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Snippet_Resources;

    public partial class Snippet
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Default = new Options();
            private string _newLine = Environment.NewLine;

            [Required(ErrorMessageResourceName = nameof(OptionsBlockRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BlockOptions Block { get; internal set; } = new BlockOptions();

            [Valuify.Ignore]
            public bool IsDefault => this == Default;

            [Range(120, 255, ErrorMessageResourceName = nameof(OptionsMaxLengthOutOfRange), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public byte MaxLength { get; internal set; } = 155;

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsNewLineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string NewLine
            {
                get => _newLine;
                set
                {
                    if (_newLine != value)
                    {
                        BlankSpace = ImmutableArray.Create(value, value);
                        _newLine = value;
                    }
                }
            }

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsWhitespaceRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Whitespace { get; internal set; } = "    ";

            [Fluentify.Ignore]
            [Valuify.Ignore]
            internal Snippet BlankSpace { get; set; } = ImmutableArray.Create(Environment.NewLine, Environment.NewLine);
        }
    }
}