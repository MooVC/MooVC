namespace MooVC.Syntax.Project.PropertyGroupTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(PropertyGroup.Condition));
    }

    [Test]
    public async Task GivenUndefinedPropertyThenValidationErrorReturned()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create(property: Property.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(PropertyGroup.Properties));
    }

    [Test]
    public async Task GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        PropertyGroup subject = PropertyGroup.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}