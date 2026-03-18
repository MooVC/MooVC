namespace MooVC.Syntax.Attributes.Project.ItemTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Item subject = Item.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Item.Condition));
    }

    [Test]
    public async Task GivenUndefinedMetadataThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(metadata: Metadata.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await results.Single();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Item.Metadata));
    }
}