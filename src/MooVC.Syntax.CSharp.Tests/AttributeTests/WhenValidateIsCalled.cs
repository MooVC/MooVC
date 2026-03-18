namespace MooVC.Syntax.CSharp.AttributeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    private const string ArgumentName = "Message";

    [Test]
    public async Task GivenUnspecifiedAttributeThenNoValidationErrorsReturned()
    {
        // Arrange
        Attribute attribute = Attribute.Unspecified;
        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnnamedAttributeThenValidationErrorReturned()
    {
        // Arrange
        var attribute = new Attribute
        {
            Arguments = [new Argument { Name = new Identifier(ArgumentName), Value = Snippet.From("value") }],
        };

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Attribute.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenArgumentWithValidationErrorsThenValidationErrorsReturned()
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
                    Value = Snippet.From($"alpha{Environment.NewLine}beta"),
                }
            ],
        };

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Argument.Value));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidAttributeThenNoValidationErrorsReturned()
    {
        // Arrange
        Attribute attribute = AttributeTestsData.Create(arguments: new Argument
        {
            Name = new Identifier(ArgumentName),
            Value = Snippet.From("value"),
        });

        var context = new ValidationContext(attribute);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(attribute, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}