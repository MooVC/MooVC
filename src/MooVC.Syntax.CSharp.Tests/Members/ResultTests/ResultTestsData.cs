namespace MooVC.Syntax.CSharp.Members.ResultTests;

internal static class ResultTestsData
{
    public const string DefaultTypeName = "Value";

    public static Result Create(Result.Kind? modifier = default, Result.Modality? mode = default, Symbol? type = default)
    {
        return new Result
        {
            Modifier = modifier ?? Result.Kind.None,
            Mode = mode ?? Result.Modality.Asynchronous,
            Type = type ?? new Symbol { Name = new Identifier(DefaultTypeName) },
        };
    }
}