namespace MooVC.Syntax.CSharp.MethodTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(parameters:
        [
            new Parameter
            {
                Default = Snippet.From($"first{Environment.NewLine}second"),
                Name = MethodTestsData.DefaultParameterName,
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        ]);

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Parameter.Default));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenInvalidResultThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(result: new Result { Modifier = Result.Kind.Ref });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Result.Type));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Method subject = Method.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUnspecifiedNameThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(name: Declaration.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Method.Name));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenValidMethodThenNoValidationErrorsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(
            parameters:
            [
                new Parameter
                {
                    Name = MethodTestsData.DefaultParameterName,
                    Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
                },
            ],
            body: Snippet.From("return value;"));

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}