namespace MooVC.Syntax.CSharp.Members.FieldTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.Elements;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenNoValidationErrorsReturned()
    {
        // Arrange
        Field subject = Field.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultilineDefaultThenValidationErrorReturned()
    {
        // Arrange
        var multiLine = Snippet.From("first", "second");
        Field subject = FieldTestsData.Create(@default: multiLine, name: "Value", type: SymbolTestsData.Create("Result"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Field.Default));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenUnnamedFieldThenValidationErrorReturned()
    {
        // Arrange
        Field subject = FieldTestsData.Create(name: null, type: SymbolTestsData.Create("Result"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Field.Name));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenValidFieldThenNoValidationErrorsReturned()
    {
        // Arrange
        Field subject = FieldTestsData.Create(type: SymbolTestsData.Create("Result"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }
}