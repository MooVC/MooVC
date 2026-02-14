namespace MooVC.Syntax.CSharp.Members.MethodTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

internal static class MethodTestsData
{
    public const string DefaultName = "Perform";
    public const string DefaultParameterName = "Value";
    public const string DefaultParameterType = "int";
    public const string DefaultResultType = "string";

    public static Method Create(
        Declaration? name = default,
        IEnumerable<Parameter>? parameters = default,
        Result? result = default,
        Scope? scope = default,
        Snippet? body = default)
    {
        var subject = new Method
        {
            Name = name ?? new Declaration { Name = DefaultName },
            Result = result ?? new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = DefaultResultType },
            },
            Parameters = Create(parameters),
        };

        if (body is not null)
        {
            subject.Body = body;
        }

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }

    [SuppressMessage("Style", "IDE0074:Use compound assignment", Justification = "Suggested approach is less readable.")]
    private static ImmutableArray<Parameter> Create(IEnumerable<Parameter>? parameters)
    {
        if (parameters is null)
        {
            parameters =
            [
                new Parameter
                {
                    Name = DefaultParameterName,
                    Type = new Symbol { Name = DefaultParameterType },
                },
            ];
        }

        return parameters.ToImmutableArray();
    }
}