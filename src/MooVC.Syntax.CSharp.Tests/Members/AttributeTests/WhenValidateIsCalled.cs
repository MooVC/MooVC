namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    private const string ArgumentName = "Message";

    [Fact]
    public void GivenUnspecifiedAttributeThenNoValidationErrorsReturned()
    {
        // Arrange
        Attribute attribute = Attribute.Unspecified;
        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedAttributeThenValidationErrorReturned()
    {
        // Arrange
        var attribute = new Attribute
        {
            Arguments = [new Argument { Name = new Identifier(ArgumentName), Value = "value" }],
        };

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Attribute.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenArgumentWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        var attribute = new Attribute
        {
            Name = new Symbol { Name = AttributeTestsData.DefaultName },
            Arguments =
            [
                new Argument
                {
                    Name = ArgumentName,
                    Value = $"alpha{Environment.NewLine}beta",
                }
            ],
        };

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Argument.Value));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidAttributeThenNoValidationErrorsReturned()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(arguments: new Argument
        {
            Name = new Identifier(ArgumentName),
            Value = "value",
        });

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}