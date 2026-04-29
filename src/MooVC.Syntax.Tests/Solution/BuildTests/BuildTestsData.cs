namespace MooVC.Syntax.Solution.BuildTests;

public static class BuildTestsData
{
    public static Build Create(
        Snippet? project = default,
        Snippet? solution = default)
    {
        return new Build
        {
            Project = project ?? Snippet.From("Debug|AnyCPU"),
            Solution = solution ?? Snippet.From("Debug|Any CPU"),
        };
    }
}