namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenInvalidValueThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Configurations.Platform(" Invalid");
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Configurations.Platform));
    }

    [Test]
    public async Task GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}