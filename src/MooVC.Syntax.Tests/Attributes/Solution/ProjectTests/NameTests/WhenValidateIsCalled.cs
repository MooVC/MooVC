namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUnnamedThenValidationIsSkipped()
    {
        // Arrange
        Project.Name subject = Project.Name.Unnamed;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenInvalidNameThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Project.Name("Invalid/Name");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Project.Name));
    }
}