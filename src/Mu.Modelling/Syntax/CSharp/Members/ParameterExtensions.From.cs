namespace Mu.Modelling.Syntax.CSharp.Members;

using MooVC.Syntax.CSharp.Elements;
using Attribute = Mu.Modelling.Attribute;
using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

internal static partial class ParameterExtensions
{
    public static Parameter From(this Parameter parameter, Attribute attribute)
    {
        return parameter
            .Named(attribute.Name)
            .OfType(attribute.Type);
    }
}