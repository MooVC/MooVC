namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Constructor subject = Constructor.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidParameterThenValidationErrorReturned()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create(parameters: [Parameter.Undefined]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Constructor.Parameters));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidConstructorThenNoValidationErrorsReturned()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create(parameters: [ParameterTestsData.Create()]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}