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
            [Required(ErrorMessageResourceName = nameof(BlockMarkersRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BoundaryOptions Markers { get; set; } = new BoundaryOptions();

            public StyleType Style { get; set; } = StyleType.Allman;
        }
    }
}