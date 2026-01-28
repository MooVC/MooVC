namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Project.RelativePath subject = Project.RelativePath.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenAbsolutePathThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Project.RelativePath("/root/Project.csproj");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Project.RelativePath));
    }
}