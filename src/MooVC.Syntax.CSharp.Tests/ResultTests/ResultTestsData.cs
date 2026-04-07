namespace MooVC.Syntax.CSharp.ResultTests;

internal static class ResultTestsData
{
    public const string DefaultTypeName = "Value";

    public static Result Create(Result.Modifiers? modifier = default, Result.Modes? mode = default, Symbol? type = default)
    {
        return new Result
        {
            Modifier = modifier ?? Result.Modifiers.None,
            Mode = mode ?? Result.Modes.Asynchronous,
            Type = type ?? new Symbol { Name = DefaultTypeName },
        };
    }
}