namespace MooVC.Syntax.Attributes.Project.SdkTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Sdk subject = Sdk.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenMultiLineMinimumVersionThenValidationErrorReturned()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create(minimumVersion: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Sdk.MinimumVersion));
    }

    [Test]
    public async Task GivenUnqualifiedNameThenValidationErrorReturned()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create(name: Qualifier.Unqualified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Sdk.Name));
    }
}