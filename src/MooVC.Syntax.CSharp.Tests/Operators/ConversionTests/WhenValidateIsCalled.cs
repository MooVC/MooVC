namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationSucceeds()
    {
        // Arrange
        Conversion subject = Conversion.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMissingBodyThenValidationFails()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(body: Snippet.Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.ShouldNotBeEmpty();
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Conversion.Body)));
    }

    [Fact]
    public void GivenMissingSubjectThenValidationFails()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(subject: Symbol.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.ShouldNotBeEmpty();
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Conversion.Subject)));
    }

    [Fact]
    public void GivenValidConversionThenValidationSucceeds()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}
