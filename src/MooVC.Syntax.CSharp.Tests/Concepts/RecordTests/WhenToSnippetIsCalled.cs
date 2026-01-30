namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Record subject = RecordTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }
}