namespace Mu.Modelling.AttributeTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        ModellingAttribute subject = ModellingAttribute.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineDefaultThenValidationErrorReturned()
    {
        // Arrange
        Snippet defaultValue = $"Alpha{Environment.NewLine}Beta";
        ModellingAttribute subject = ModellingTestData.CreateAttribute(defaultValue: defaultValue);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(ModellingAttribute.Default));
    }
}