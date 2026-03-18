namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Test]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Metadata subject = Metadata.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Test]
    public void GivenMultiLineMimeTypeThenValidationErrorReturned()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create(mimeType: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Metadata.MimeType));
    }

    [Test]
    public void GivenMultiLineNameThenValidationErrorReturned()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create(name: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Metadata.Name));
    }

    [Test]
    public void GivenMultiLineTypeThenValidationErrorReturned()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create(type: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Metadata.Type));
    }
}