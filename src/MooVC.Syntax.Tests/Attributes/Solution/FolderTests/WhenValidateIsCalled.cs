namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Folder subject = Folder.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenInvalidNameThenValidationErrorReturned()
    {
        // Arrange
        Folder subject = FolderTestsData.Create(name: new Folder.Path("invalid"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Folder.Path));
    }

    [Test]
    public void GivenUndefinedFileThenValidationErrorReturned()
    {
        // Arrange
        Folder subject = FolderTestsData.Create(file: File.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Folder.Files));
    }
}