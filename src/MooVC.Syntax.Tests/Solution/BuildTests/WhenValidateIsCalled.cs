namespace MooVC.Syntax.Solution.BuildTests;

using System.ComponentModel.DataAnnotations;
using System.Linq;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsNoValidationResults()
    {
        // Arrange
        var subject = new Build();
        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext).ToArray();

        // Assert
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenMultiLineProjectOrSolutionThenReturnsValidationResults()
    {
        // Arrange
        var subject = new Build
        {
            Project = Snippet.From("Debug", "AnyCPU"),
            Solution = Snippet.From("Debug", "Any CPU"),
        };

        var validationContext = new ValidationContext(subject);

        // Act
        var results = subject.Validate(validationContext).ToArray();

        // Assert
        _ = await Assert.That(results).IsNotEmpty();
    }
}