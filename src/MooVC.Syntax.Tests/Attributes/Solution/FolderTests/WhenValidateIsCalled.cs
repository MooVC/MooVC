namespace MooVC.Syntax.Attributes.Solution.FolderTests;

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
        Folder subject = Folder.Undefined;
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
        Folder subject = FolderTestsData.Create(id: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Folder.Id));
    }

    [Fact]
    public void GivenMultiLineNameThenValidationErrorReturned()
    {
        // Arrange
        Folder subject = FolderTestsData.Create(name: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Folder.Name));
    }
}