namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Generics;
using Identifier = MooVC.Syntax.CSharp.Members.Identifier;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Result";

    [Fact]
    public void GivenUnspecifiedDeclarationThenNoValidationErrorsReturned()
    {
        // Arrange
        Declaration declaration = Declaration.Unspecified;
        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedDeclarationThenValidationErrorReturned()
    {
        // Arrange
        var declaration = new Declaration();
        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Declaration.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        var declaration = new Declaration
        {
            Name = new Identifier(Name),
            Parameters = [new Parameter()],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidDeclarationThenNoValidationErrorsReturned()
    {
        // Arrange
        var declaration = new Declaration
        {
            Name = new Identifier(Name),
            Parameters = [new Parameter { Name = "T" }],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}