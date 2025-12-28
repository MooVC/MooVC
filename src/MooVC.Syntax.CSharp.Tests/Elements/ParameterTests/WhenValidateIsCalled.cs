namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

public sealed class WhenValidateIsCalled
{
    private const string AttributeName = "Obsolete";

    [Fact]
    public void GivenUndefinedParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = Parameter.Undefined;
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedParameterThenValidationErrorReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(name: null);
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenDefaultWithMultipleLinesThenValidationErrorReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(@default: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Default));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenAttributesWithValidationErrorsThenValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            name: ParameterTestsData.DefaultName,
            attributes: new Attribute
            {
                Name = Symbol.Undefined,
            });

        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(parameter.Attributes));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            modifier: Parameter.Mode.Out,
            attributes: new Attribute
            {
                Name = new Symbol { Name = new Identifier(AttributeName) },
            });

        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}