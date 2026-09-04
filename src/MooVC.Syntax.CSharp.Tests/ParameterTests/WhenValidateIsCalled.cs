namespace MooVC.Syntax.CSharp.ParameterTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string AttributeName = "Obsolete";

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
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(parameter.Attributes));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
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
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Default));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

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
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
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
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidParameterThenNoValidationErrorsReturned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create(
            modifier: Parameter.Modes.Out,
            attributes: new Attribute
            {
                Name = new() { Name = AttributeName },
            });

        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(parameter, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}