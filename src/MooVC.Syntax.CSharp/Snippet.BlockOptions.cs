namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Snippet_Resources;

    public partial class Snippet
    {
        [Fluentify]
        [Valuify]
        public sealed partial class BlockOptions
        {
            [Required(ErrorMessageResourceName = nameof(BlockOptionsMarkersRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BoundaryOptions Markers { get; set; } = new BoundaryOptions();

            [Required(ErrorMessageResourceName = nameof(BlockOptionsInlineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Inline { get; set; } = InlineStyle.Lambda;

            [Required(ErrorMessageResourceName = nameof(BlockOptionsStyleRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public StyleType Style { get; set; } = StyleType.Allman;
        }
    }
}