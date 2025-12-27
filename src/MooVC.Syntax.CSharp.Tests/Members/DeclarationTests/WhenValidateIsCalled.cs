namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Identifier = MooVC.Syntax.CSharp.Members.Identifier;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

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
        var declaration = new Declaration
        {
            Parameters = [new Parameter { Name = "T" }],
        };

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
            Parameters = [new Parameter { Name = "Invalid Name" }],
        };

        var context = new ValidationContext(declaration);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(declaration, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Identifier));
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