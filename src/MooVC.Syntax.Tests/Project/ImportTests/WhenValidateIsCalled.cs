namespace MooVC.Syntax.Project.ImportTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"), project: Snippet.From("Project"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Import.Condition));
    }

    [Test]
    public async Task GivenSingleLineProjectThenNoValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(project: Snippet.From("Project"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
    }

    [Test]
    public async Task GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Import subject = Import.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}