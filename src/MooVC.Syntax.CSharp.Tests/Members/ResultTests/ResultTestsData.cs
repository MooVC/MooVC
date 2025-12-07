namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp.Members;

public static class ResultTestsData
{
    public static readonly Symbol DefaultType = typeof(string);

    public static Result Create(Result.Kind? modifier = default, Result.Modality? mode = default, Symbol? type = default)
    {
        return new Result
        {
            Mode = mode ?? Result.Modality.Asynchronous,
            Modifier = modifier ?? Result.Kind.None,
            Type = type ?? DefaultType,
        };
    }
}
