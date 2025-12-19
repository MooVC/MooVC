namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System;
using MooVC.Syntax.CSharp.Members;

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