namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string Name = "Result";
    private const string ArgumentName = "Inner";

    [Fact]
    public void GivenUnspecifiedSymbolThenNoValidationErrorsReturned()
    {
        // Arrange
        Symbol symbol = Symbol.Undefined;
        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedSymbolThenValidationErrorReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new Symbol { Name = "Test" }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Symbol.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenUnspecifiedArgumentThenValidationErrorReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = new Identifier(Name),
            Arguments = [Symbol.Undefined],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Symbol.Arguments));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenArgumentWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Arguments = [new Symbol { Name = "Invalid Name" }],
            Name = new Identifier(Name),
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Identifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenQualifierWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = new Identifier(Name),
            Qualifier = new Segment[] { Segment.Empty },
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain($"{nameof(Symbol.Qualifier)}[0]");
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidSymbolThenNoValidationErrorsReturned()
    {
        // Arrange
        var symbol = new Symbol
        {
            Name = new Identifier(Name),
            Arguments = [new Symbol { Name = new Identifier(ArgumentName) }],
        };

        var context = new ValidationContext(symbol);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(symbol, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}