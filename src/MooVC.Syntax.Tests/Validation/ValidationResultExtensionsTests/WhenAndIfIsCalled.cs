namespace MooVC.Syntax.Validation.ValidationResultExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenAndIfIsCalled
{
    private const string Message = "Validated";

    [Test]
    public async Task GivenFalseConditionThenPrecedingResultIsReturned()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var validatable = new TrackingValidatable(initial);
        var context = new ValidationContext(validatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(preceding),
            validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            false,
            nameof(validatable),
            validatable);

        // Assert
        await Assert.That(actual).IsEqualTo(preceding);
        await Assert.That(validatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenTrueConditionThenValidationIsAppended()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var precedingValidatable = new TrackingValidatable(initial);
        var additionalValidatable = new TrackingValidatable(new ValidationResult("Additional"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            true,
            nameof(additionalValidatable),
            additionalValidatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = actual.Results.ToArray();
        await Assert.That(results).IsEqualTo([initial, additionalValidatable.Results.Single()]);
        await Assert.That(precedingValidatable.Calls).IsEqualTo(1);
        await Assert.That(additionalValidatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFalseConditionAndMultipleValidatablesThenPrecedingResultIsReturned()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var precedingValidatable = new TrackingValidatable(initial);
        var firstAdditional = new TrackingValidatable(new ValidationResult("First"));
        var secondAdditional = new TrackingValidatable(new ValidationResult("Second"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            false,
            nameof(firstAdditional),
            [firstAdditional, secondAdditional]);

        // Assert
        await Assert.That(actual).IsEqualTo(preceding);
        await Assert.That(precedingValidatable.Calls).IsEqualTo(1);
        await Assert.That(firstAdditional.Calls).IsEqualTo(0);
        await Assert.That(secondAdditional.Calls).IsEqualTo(0);
    }

    [Test]
    public async Task GivenTrueConditionAndMultipleValidatablesThenValidationIsAppended()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var precedingValidatable = new TrackingValidatable(initial);
        var firstAdditional = new TrackingValidatable(new ValidationResult("First"));
        var secondAdditional = new TrackingValidatable(new ValidationResult("Second"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            true,
            nameof(firstAdditional),
            [firstAdditional, secondAdditional]);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = actual.Results.ToArray();
        await Assert.That(results).IsEqualTo([initial, firstAdditional.Results.Single(), secondAdditional.Results.Single()]);
        await Assert.That(precedingValidatable.Calls).IsEqualTo(1);
        await Assert.That(firstAdditional.Calls).IsEqualTo(1);
        await Assert.That(secondAdditional.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFunctionConditionThenItDeterminesWhetherValidationOccurs()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var precedingValidatable = new TrackingValidatable(initial);
        var additionalValidatable = new TrackingValidatable(new ValidationResult("Additional"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            () => true,
            nameof(additionalValidatable),
            additionalValidatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = actual.Results.ToArray();
        await Assert.That(results).IsEqualTo([initial, additionalValidatable.Results.Single()]);
        await Assert.That(precedingValidatable.Calls).IsEqualTo(1);
        await Assert.That(additionalValidatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFunctionConditionAndValidatablesThenItDeterminesWhetherValidationOccurs()
    {
        // Arrange
        var initial = new ValidationResult(Message);
        var precedingValidatable = new TrackingValidatable(initial);
        var additionalValidatable = new TrackingValidatable(new ValidationResult("Additional"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.AndIf(
            () => false,
            nameof(additionalValidatable),
            [additionalValidatable]);

        // Assert
        await Assert.That(actual).IsEqualTo(preceding);
        await Assert.That(precedingValidatable.Calls).IsEqualTo(1);
        await Assert.That(additionalValidatable.Calls).IsEqualTo(0);
    }

    private sealed class TrackingValidatable : IValidatableObject
    {
        public TrackingValidatable(params ValidationResult[] results)
        {
            Results = results;
        }

        public int Calls { get; private set; }

        public IReadOnlyCollection<ValidationResult> Results { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Calls++;

            return Results;
        }
    }
}