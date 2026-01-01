namespace MooVC.Syntax.Concepts.ProjectTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Project;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Project subject = Project.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUndefinedImportThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(import: Import.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Project.Imports));
    }

    [Fact]
    public void GivenUnspecifiedSdkThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(sdk: Sdk.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Project.Sdks));
    }
}