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
        public sealed partial class BoundaryOptions
        {
            internal BoundaryOptions()
            {
            }

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryClosingRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Closing { get; set; } = "}";

            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryOpeningRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Opening { get; set; } = "{";
        }
    }
}