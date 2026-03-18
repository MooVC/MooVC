namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;
using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

public sealed class WhenValidateIsCalled
{
    private const string AttributeName = "Obsolete";

    [Test]
    public async Task GivenUndefinedParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = Parameter.Undefined;
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnnamedParameterThenValidationErrorReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(name: null);
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenDefaultWithMultipleLinesThenValidationErrorReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(@default: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Default));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenAttributesWithValidationErrorsThenValidationErrorsReturned()
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
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(parameter.Attributes));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            modifier: Parameter.Mode.Out,
            attributes: new Attribute
            {
                Name = new Symbol { Name = AttributeName },
            });

        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }
}