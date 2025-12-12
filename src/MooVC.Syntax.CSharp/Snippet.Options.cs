namespace MooVC.Syntax.CSharp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Snippet_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Snippet
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Default = new Options();

            [Required(ErrorMessageResourceName = nameof(OptionsBlockRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BlockOptions Block { get; set; } = new BlockOptions();

            [Ignore]
            public bool IsDefault => this == Default;

            [Range(120, 255, ErrorMessageResourceName = nameof(OptionsMaxLengthOutOfRange), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public byte MaxLength { get; set; } = 155;

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsNewLineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string NewLine { get; set; } = Environment.NewLine;

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsWhitespaceRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Whitespace { get; set; } = "    ";
        }
    }
}