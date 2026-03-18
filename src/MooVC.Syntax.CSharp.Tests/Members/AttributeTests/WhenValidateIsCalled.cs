namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
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
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Attribute.Name));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
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
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Argument.Value));
        await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
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
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }
}