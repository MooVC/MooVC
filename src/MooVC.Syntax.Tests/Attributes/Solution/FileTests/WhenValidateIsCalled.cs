namespace MooVC.Syntax.Attributes.Solution.FileTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        File subject = File.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenAbsolutePathThenValidationErrorReturned()
    {
        // Arrange
        var subject = new File("/root/file.cs");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(File));
    }

    [Test]
    public void GivenInvalidCharactersThenValidationErrorReturned()
    {
        // Arrange
        var subject = new File("src/file?.cs");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(File));
    }

    [Test]
    public void GivenValidPathThenValidationSucceeds()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}