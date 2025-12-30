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
        public sealed partial class BlockOptions
        {
            internal BlockOptions()
            {
            }

            [Required(ErrorMessageResourceName = nameof(BlockOptionsMarkersRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BoundaryOptions Markers { get; internal set; } = new BoundaryOptions();

            [Required(ErrorMessageResourceName = nameof(BlockOptionsInlineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Inline { get; internal set; } = InlineStyle.Lambda;

            [Required(ErrorMessageResourceName = nameof(BlockOptionsStyleRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public StyleType Style { get; internal set; } = StyleType.Allman;
        }
    }
}