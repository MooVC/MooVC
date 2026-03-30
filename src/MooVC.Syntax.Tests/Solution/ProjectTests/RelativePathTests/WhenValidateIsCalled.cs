namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenAbsolutePathThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Project.RelativePath("/root/Project.csproj");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Project.RelativePath));
    }

    [Test]
    public async Task GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Project.RelativePath subject = Project.RelativePath.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}