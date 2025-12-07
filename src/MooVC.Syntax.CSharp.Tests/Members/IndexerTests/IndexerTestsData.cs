using MooVC.Syntax.CSharp.Members;

namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public static class IndexerTestsData
{
    public const string DefaultParameterName = "index";

    public static readonly Symbol DefaultParameterType = typeof(int);
    public static readonly Symbol DefaultResult = typeof(string);

    public static Indexer Create(
        Parameter? parameter = default,
        Result? result = default,
        Scope? scope = default)
    {
        Parameter parameterValue = parameter ?? new Parameter
        {
            Name = new Identifier(DefaultParameterName),
            Type = DefaultParameterType,
        };

        Result resultValue = result ?? new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = DefaultResult,
        };

        return new Indexer
        {
            Parameter = parameterValue,
            Result = resultValue,
            Scope = scope ?? Scope.Public,
        };
    }
}
