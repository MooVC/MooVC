namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

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
        TaskParameter subject = TaskParameter.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnnamedNameThenValidationErrorReturned()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create(name: Identifier.Unnamed);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskParameter.Name));
    }

    [Fact]
    public void GivenMultiLineValueThenValidationErrorReturned()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create(value: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(TaskParameter.Value));
    }
}