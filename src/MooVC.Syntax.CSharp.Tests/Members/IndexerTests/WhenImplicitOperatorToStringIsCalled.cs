namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        Indexer? subject = default;

        // Act
        Func<string> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenIndexerThenStringMatchesToString()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
