namespace Mu.Modelling.Syntax.CSharp.Members;

using MooVC.Syntax.CSharp.Members;
using Attribute = Mu.Modelling.Attribute;

internal static partial class PropertyExtensions
{
    public static Property From(this Property property, Attribute attribute)
    {
        return property
            .Named(attribute.Name)
            .OfType(attribute.Type)
            .WithDefault(attribute.Default);
    }
}