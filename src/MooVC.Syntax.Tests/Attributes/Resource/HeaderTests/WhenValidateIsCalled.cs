namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Header subject = Header.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineNameThenValidationErrorReturned()
    {
        // Arrange
        Header subject = HeaderTestsData.Create(name: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Header.Name));
    }

    [Fact]
    public void GivenMultiLineValueThenValidationErrorReturned()
    {
        // Arrange
        Header subject = HeaderTestsData.Create(value: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Header.Value));
    }
}