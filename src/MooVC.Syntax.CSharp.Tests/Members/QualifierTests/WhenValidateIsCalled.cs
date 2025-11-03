namespace MooVC.Syntax.CSharp.Members.QualifierTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenDefaultValueThenValidationErrorReturned()
    {
        // Arrange
        var qualifier = new Qualifier(default);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Qualifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenEmptyArrayThenValidationErrorReturned()
    {
        // Arrange
        var qualifier = new Qualifier([]);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain(nameof(Qualifier));
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GivenSegmentsThenNoValidationErrorReturned()
    {
        // Arrange
        ImmutableArray<Segment> value = ["Alpha", "Beta"];
        var qualifier = new Qualifier(value);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void GivenNullSegmentThenValidationErrorReturned()
    {
        // Arrange
        Segment[] values = [new("Alpha"), default!];

        Qualifier qualifier = values;
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        results.Count.ShouldBe(1);
        results[0].MemberNames.ShouldContain("Qualifier[1]");
        results[0].ErrorMessage.ShouldNotBeNullOrWhiteSpace();
    }
}