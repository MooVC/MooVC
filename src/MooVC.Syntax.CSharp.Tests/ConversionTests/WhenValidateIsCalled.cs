namespace MooVC.Syntax.CSharp.ConversionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenMissingBodyThenValidationFails()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(body: Snippet.Empty);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).IsNotEmpty();
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Conversion.Body)));
    }

    [Test]
    public async Task GivenMissingSubjectThenValidationFails()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(subject: Symbol.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).IsNotEmpty();
        _ = await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(Conversion.Target)));
    }

    [Test]
    public async Task GivenUndefinedThenValidationSucceeds()
    {
        // Arrange
        Conversion subject = Conversion.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenValidConversionThenValidationSucceeds()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}