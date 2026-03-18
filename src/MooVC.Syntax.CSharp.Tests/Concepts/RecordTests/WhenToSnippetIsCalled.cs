namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Record subject = RecordTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }
}