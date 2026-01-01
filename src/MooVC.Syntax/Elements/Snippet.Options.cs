namespace MooVC.Syntax.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Elements.Snippet_Resources;

    public partial class Snippet
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Default = new Options();

            [Required(ErrorMessageResourceName = nameof(OptionsBlockRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BlockOptions Block { get; internal set; } = new BlockOptions();

            [Valuify.Ignore]
            public bool IsDefault => this == Default;

            [Range(120, 255, ErrorMessageResourceName = nameof(OptionsMaxLengthOutOfRange), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public byte MaxLength { get; internal set; } = 155;

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsWhitespaceRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public Snippet Whitespace { get; internal set; } = StringExtensions.ToSnippet("    ");
        }
    }
}