namespace Mu.Modelling.Syntax.CSharp.Concepts;

using MooVC;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Members;
using Attribute = Mu.Modelling.Attribute;

internal static partial class RecordExtensions
{
    public static Record WithProperties(this Record record, IEnumerable<Attribute> attributes)
    {
        return record.Enumerate(
            (attribute, record) => record.WithProperties(property => property.From(attribute)),
            attributes);
    }
}