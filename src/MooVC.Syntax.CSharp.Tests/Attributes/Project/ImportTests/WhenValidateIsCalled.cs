namespace MooVC.Syntax.CSharp.Attributes.Project.ImportTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Import subject = Import.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"), project: Snippet.From("Project"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Import.Condition));
    }

    [Fact]
    public void GivenSingleLineProjectThenNoValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(project: Snippet.From("Project"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
    }
}