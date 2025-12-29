namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        TaskOutput subject = TaskOutput.Undefined;
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
        TaskOutput subject = TaskOutputTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.Condition));
    }

    [Fact]
    public void GivenItemWithoutPropertyThenValidationErrorReturned()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create(propertyName: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.PropertyName));
    }

    [Fact]
    public void GivenPropertyWithoutItemThenValidationErrorReturned()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create(itemName: Identifier.Unnamed, propertyName: new Identifier("Property"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskOutput.ItemName));
    }
}