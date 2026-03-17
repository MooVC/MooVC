namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenValidationErrorReturned()
    {
        // Arrange
        Comparison subject = Comparison.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Comparison.Body));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Test]
    public void GivenBodyThenValidationSucceeds()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}