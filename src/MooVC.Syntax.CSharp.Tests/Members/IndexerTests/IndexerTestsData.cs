namespace MooVC.Syntax.CSharp.Members.IndexerTests;

internal static class IndexerTestsData
{
    public const string DefaultParameterName = "index";
    public const string DefaultParameterType = "int";
    public const string DefaultResultType = "string";

    public static Indexer Create(
        Parameter? parameter = default,
        Result? result = default,
        Indexer.Methods? behaviours = default,
        Scope? scope = default)
    {
        var subject = new Indexer
        {
            Parameter = parameter ?? new Parameter
            {
                Name = DefaultParameterName,
                Type = new Symbol { Name = DefaultParameterType },
            },
            Result = result ?? new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = DefaultResultType },
            },
        };

        if (behaviours is not null)
        {
            subject.Behaviours = behaviours;
        }

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}