namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string ValidSimple = "T";
    private const string ValidComplex = "TValue";
    private const string InvalidLowercase = "tValue";

    [Fact]
    public void GivenUnnamedIdentifierThenNoValidationErrorsReturned()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Theory]
    [InlineData(ValidSimple)]
    [InlineData(ValidComplex)]
    public void GivenValidNamesThenNoValidationErrorsReturned(string name)
    {
        // Arrange
        var subject = new Identifier(name);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenNullNameThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Identifier(default(string?));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Identifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyNameThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Identifier(" ");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Identifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidNameThenValidationErrorsReturned()
    {
        // Arrange
        var subject = new Identifier(InvalidLowercase);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Identifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}