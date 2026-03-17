namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Alias = "Alias";
    private const string InvalidAlias = "alias";

    [Test]
    public void GivenUndefinedDirectiveThenValidationIsSkipped()
    {
        // Arrange
        Directive subject = Directive.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenStaticAliasThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Name(Alias),
            IsStatic = true,
            Qualifier = new Qualifier(["System", "Console"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Directive.Alias));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenInvalidAliasThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Name(InvalidAlias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenInvalidQualifierThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier([Name.Unnamed, "Syntax"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain("Qualifier[0]");
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenValidDirectiveThenNoValidationErrorsReturned()
    {
        // Arrange
        var subject = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}