namespace Mu.Modelling.Syntax.CSharp.Members;

using System.ComponentModel;
using MooVC;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Attribute = Mu.Modelling.Attribute;
using Modelling = Mu.Modelling.Parameter;
using Result = Mu.Modelling.Result;

internal static partial class ParameterExtensions
{
    public static Parameter From(this Parameter parameter, Attribute attribute)
    {
        return parameter
            .Named(attribute.Name)
            .OfType(attribute.Type);
    }

    public static Parameter From(this Parameter parameter, Modelling source)
    {
        return parameter
            .Named(source.Name)
            .OfType(source.Type);
    }

    public static Parameter From(this Parameter parameter, Result result)
    {
        return parameter
            .ForkOn(
                _ => result.Description.IsUndescribed,
                @true: _ => _,
                @false: parameter => parameter
                    .AttributedWith(description => description
                        .Named(typeof(DescriptionAttribute))
                        .WithArguments((Name: nameof(Description), Value: result.Description))))
            .Named(result.Name)
            .OfType(result.Type);
    }
}