namespace MooVC.Syntax.Attributes.Solution.FolderPathTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenRootThenValidationIsSkipped()
    {
        // Arrange
        Folder.Path subject = Folder.Path.Root;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidPathThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Folder.Path("invalid");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Folder.Path));
    }
}