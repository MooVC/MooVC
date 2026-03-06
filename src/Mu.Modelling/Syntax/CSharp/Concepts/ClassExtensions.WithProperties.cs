namespace Mu.Modelling.Syntax.CSharp.Concepts;

using MooVC;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Members;
using Attribute = Mu.Modelling.Attribute;

internal static partial class ClassExtensions
{
    public static Class WithProperties(this Class @class, IEnumerable<Attribute> attributes)
    {
        return @class.Enumerate(
            (attribute, @class) => @class.WithProperties(property => property.From(attribute)),
            attributes);
    }
}