namespace Mu.Modelling.Syntax.CSharp.Concepts;

using MooVC;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Members;
using Attribute = Mu.Modelling.Attribute;
using Parameter = Mu.Modelling.Parameter;
using Result = Mu.Modelling.Result;

internal static partial class RecordExtensions
{
    public static Record WithParameters(this Record record, IEnumerable<Attribute> attributes)
    {
        return record.Enumerate(
            (current, record) => record.WithParameters(parameter => parameter.From(current)),
            attributes);
    }

    public static Record WithParameters(this Record record, IEnumerable<Parameter> parameters)
    {
        return record.Enumerate(
            (current, record) => record.WithParameters(parameter => parameter.From(current)),
            parameters);
    }

    public static Record WithParameters(this Record record, IEnumerable<Result> results)
    {
        return record.Enumerate(
            (current, record) => record.WithParameters(parameter => parameter.From(current)),
            results);
    }
}