namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedOperatorsThenNoValidationErrorsReturned()
    {
        // Arrange
        Operators subject = Operators.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidBinaryThenValidationErrorsReturned()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create(binaries: [new Binary()]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.ShouldNotBeEmpty();
        results.ShouldContain(result => result.MemberNames.Contains(nameof(Binary.Body)));
    }

    [Fact]
    public void GivenValidOperatorsThenNoValidationErrorsReturned()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}
