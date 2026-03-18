namespace MooVC.Syntax.Validation.ValidationContextExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenIncludeIfIsCalled
{
    private const string InitialMessage = "Initial";
    private const string Message = "Validated";

    [Test]
    public async Task GivenFalseConditionThenValidationIsNotPerformed()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            false,
            nameof(validatable),
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();
        await Assert.That(actual.Results).IsEmpty();
        await Assert.That(validatable.Calls).IsEqualTo(0);
    }

    [Test]
    public async Task GivenTrueConditionThenValidationResultsAreReturned()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            true,
            nameof(validatable),
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results).IsEqualTo([validatable.Results.Single()]);
        await Assert.That(validatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenExistingResultsAndFalseConditionThenResultsAreUnchanged()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            false,
            nameof(validatable),
            results,
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] combined = [.. actual.Results];
        await Assert.That(combined).IsEqualTo([initial]);
        await Assert.That(validatable.Calls).IsEqualTo(0);
    }

    [Test]
    public async Task GivenExistingResultsAndTrueConditionThenValidationResultsAreAppended()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            true,
            nameof(validatable),
            results,
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] combined = [.. actual.Results];
        await Assert.That(combined).IsEqualTo([initial, validatable.Results.Single()]);
        await Assert.That(validatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenMultipleValidatablesAndFalseConditionThenValidationIsNotPerformed()
    {
        // Arrange
        var first = new TrackingValidatable(new ValidationResult("First"));
        var second = new TrackingValidatable(new ValidationResult("Second"));
        var context = new ValidationContext(first);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            false,
            nameof(first),
            [first, second]);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();
        await Assert.That(actual.Results).IsEmpty();
        await Assert.That(first.Calls).IsEqualTo(0);
        await Assert.That(second.Calls).IsEqualTo(0);
    }

    [Test]
    public async Task GivenMultipleValidatablesAndTrueConditionThenAllAreValidated()
    {
        // Arrange
        var first = new TrackingValidatable(new ValidationResult("First"));
        var second = new TrackingValidatable(new ValidationResult("Second"));
        var context = new ValidationContext(first);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            true,
            nameof(first),
            [first, second]);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results).IsEqualTo([first.Results.Single(), second.Results.Single()]);
        await Assert.That(first.Calls).IsEqualTo(1);
        await Assert.That(second.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFunctionConditionThenItsValueDeterminesWhetherValidationOccurs()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            () => true,
            nameof(validatable),
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results).IsEqualTo([validatable.Results.Single()]);
        await Assert.That(validatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFunctionConditionAndExistingResultsThenItsValueDeterminesWhetherValidationOccurs()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            () => false,
            nameof(validatable),
            results,
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] combined = [.. actual.Results];
        await Assert.That(combined).IsEqualTo([initial]);
        await Assert.That(validatable.Calls).IsEqualTo(0);
    }

    [Test]
    public async Task GivenPredicateAndTrueConditionThenPredicateOutcomeAffectsResults()
    {
        // Arrange
        const string memberName = "member";
        var validatable = new TrackingValidatable();
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            true,
            memberName,
            _ => false,
            validatable);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(memberName);
        await Assert.That(validatable.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenPredicateAndFalseConditionThenValidationIsSkipped()
    {
        // Arrange
        const string memberName = "member";
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult(InitialMessage);
        IEnumerable<ValidationResult> results = [initial];
        bool predicateInvoked = false;

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            false,
            memberName,
            _ => predicateInvoked = true,
            results,
            validatable);

        // Assert
        await Assert.That(predicateInvoked).IsFalse();
        await Assert.That(validatable.Calls).IsEqualTo(0);
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();
        await Assert.That(actual.Results).IsEqualTo(results);
    }

    [Test]
    public async Task GivenPredicateAndMultipleValidatablesWhenConditionTrueThenPredicateResultsAreIncluded()
    {
        // Arrange
        const string memberName = "member";
        var first = new TrackingValidatable();
        var second = new TrackingValidatable();
        var context = new ValidationContext(first);
        var initial = new ValidationResult(InitialMessage);
        IEnumerable<ValidationResult> results = [initial];

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            true,
            memberName,
            validatable => validatable == first,
            results,
            [first, second]);

        // Assert
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] combined = [.. actual.Results];
        await Assert.That(combined.Length).IsEqualTo(2);
        await Assert.That(combined).Contains(initial);
        await Assert.That(combined).Contains(result => result.MemberNames.Contains(memberName));
        await Assert.That(first.Calls).IsEqualTo(1);
        await Assert.That(second.Calls).IsEqualTo(1);
    }

    [Test]
    public async Task GivenFunctionConditionWithPredicateWhenFalseThenValidationIsSkipped()
    {
        // Arrange
        const string memberName = "member";
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult(InitialMessage);
        IEnumerable<ValidationResult> results = [initial];
        bool predicateInvoked = false;
        bool conditionInvoked = false;

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(
            () =>
            {
                conditionInvoked = true;
                return false;
            },
            memberName,
            _ => predicateInvoked = true,
            results,
            validatable);

        // Assert
        await Assert.That(conditionInvoked).IsTrue();
        await Assert.That(predicateInvoked).IsFalse();
        await Assert.That(validatable.Calls).IsEqualTo(0);
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();
        await Assert.That(actual.Results).IsEqualTo(results);
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