namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Item subject = Item.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineIdThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(id: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Id));
    }

    [Fact]
    public void GivenMultiLineNameThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(name: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Name));
    }

    [Fact]
    public void GivenMultiLinePathThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(path: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Path));
    }

    [Fact]
    public void GivenMultiLineTypeThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(type: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Type));
    }
}