namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedIndexerThenEmptyStringReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenIndexerWithValuesThenSignatureReturned()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(" ".Combine(subject.Scope, subject.Parameter, subject.Result));
    }
}
