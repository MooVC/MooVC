namespace MooVC.Syntax.Concepts.ProjectTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Project;
using Resource = MooVC.Syntax.Attributes.Resource.Resource;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Project subject = Project.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedImportThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(import: Import.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Project.Imports));
    }

    [Test]
    public async Task GivenUnspecifiedSdkThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(sdk: Sdk.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Project.Sdks));
    }

    [Test]
    public async Task GivenUndefinedResourceThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(resource: Resource.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Project.Resources));
    }
}