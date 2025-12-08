namespace MooVC.Syntax.CSharp.Members.MethodTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Method subject = Method.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnspecifiedNameThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(name: Declaration.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Method.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(parameters: new[]
        {
            new Parameter
            {
                Default = Snippet.From($"first{Environment.NewLine}second"),
                Name = MethodTestsData.DefaultParameterName,
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        });

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Parameter.Default));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenInvalidResultThenValidationErrorReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(result: new Result { Modifier = Result.Kind.Ref });
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Result.Type));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidMethodThenNoValidationErrorsReturned()
    {
        // Arrange
        Method subject = MethodTestsData.Create(parameters: new[]
        {
            new Parameter
            {
                Name = MethodTestsData.DefaultParameterName,
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
        }, body: Snippet.From("return value;"));

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}
