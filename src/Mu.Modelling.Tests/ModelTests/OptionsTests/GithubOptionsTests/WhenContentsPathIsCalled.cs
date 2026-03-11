namespace Mu.Modelling.ModelTests.OptionsTests.GithubOptionsTests;

public sealed class WhenContentsPathIsCalled
{
    private const string ApiBaseAddress = "https://api.github.com/";
    private const string Owner = "owner";
    private const string Reference = "main";
    private const string RelativePath = "source/File.cs";
    private const string Repository = "repository";

    [Fact]
    public void GivenGithubOptionsThenContentsPathsAreReturned()
    {
        // Arrange
        var subject = new Model.Options.GithubOptions(ApiBaseAddress, Owner, Repository, Reference, string.Empty);

        // Act
        string repositoryPath = subject.ContentsPath(string.Empty);
        string filePath = subject.ContentsPath(RelativePath);

        // Assert
        repositoryPath.ShouldBe($"repos/{Owner}/{Repository}/contents?ref={Reference}");
        filePath.ShouldBe($"repos/{Owner}/{Repository}/contents/{RelativePath}?ref={Reference}");
    }
}