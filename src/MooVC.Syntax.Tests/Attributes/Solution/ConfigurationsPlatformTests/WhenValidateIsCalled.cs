namespace MooVC.Syntax.Attributes.Solution.ConfigurationsPlatformTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenInvalidValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Configurations.Platform(" Invalid");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Configurations.Platform));
    }
}