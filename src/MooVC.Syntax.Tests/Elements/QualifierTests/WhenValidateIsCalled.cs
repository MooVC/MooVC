namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenDefaultValueThenValidationErrorReturned()
    {
        // Arrange
        var qualifier = new Qualifier(default);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Qualifier));
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }

    [Test]
    public async Task GivenEmptyArrayThenNoValidationErrorReturned()
    {
        // Arrange
        var qualifier = new Qualifier([]);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenSegmentsThenNoValidationErrorReturned()
    {
        // Arrange
        ImmutableArray<Name> value = ["Alpha", "Beta"];
        var qualifier = new Qualifier(value);
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results.Count).IsEqualTo(0);
    }

    [Test]
    public async Task GivenNullSegmentThenValidationErrorReturned()
    {
        // Arrange
        Name[] values = [new("Alpha"), default!];

        Qualifier qualifier = values;
        var context = new ValidationContext(qualifier);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(qualifier, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains("Qualifier[1]");
        _ = await Assert.That(results[0].ErrorMessage).IsNotNull().And.IsNotEmpty();
    }
}