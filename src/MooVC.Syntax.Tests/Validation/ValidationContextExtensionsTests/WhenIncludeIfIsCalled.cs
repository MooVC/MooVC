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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);
        _ = await Assert.That(actual.Results).IsEmpty();
        _ = await Assert.That(validatable.Calls).IsEqualTo(0);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).IsEquivalentTo([validatable.Results.Single()]);
        _ = await Assert.That(validatable.Calls).IsEqualTo(1);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined).IsEquivalentTo([initial]);
        _ = await Assert.That(validatable.Calls).IsEqualTo(0);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined).IsEquivalentTo([initial, validatable.Results.Single()]);
        _ = await Assert.That(validatable.Calls).IsEqualTo(1);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);
        _ = await Assert.That(actual.Results).IsEmpty();
        _ = await Assert.That(first.Calls).IsEqualTo(0);
        _ = await Assert.That(second.Calls).IsEqualTo(0);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).IsEquivalentTo([first.Results.Single(), second.Results.Single()]);
        _ = await Assert.That(first.Calls).IsEqualTo(1);
        _ = await Assert.That(second.Calls).IsEqualTo(1);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).IsEquivalentTo([validatable.Results.Single()]);
        _ = await Assert.That(validatable.Calls).IsEqualTo(1);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined).IsEquivalentTo([initial]);
        _ = await Assert.That(validatable.Calls).IsEqualTo(0);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] results = [.. actual.Results];
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(memberName);
        _ = await Assert.That(validatable.Calls).IsEqualTo(1);
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
        _ = await Assert.That(predicateInvoked).IsFalse();
        _ = await Assert.That(validatable.Calls).IsEqualTo(0);
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);
        _ = await Assert.That(actual.Results).IsEqualTo(results);
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
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);

        ValidationResult[] combined = [.. actual.Results];
        _ = await Assert.That(combined.Length).IsEqualTo(2);
        _ = await Assert.That(combined).Contains(initial);
        _ = await Assert.That(combined).Contains(result => result.MemberNames.Contains(memberName));
        _ = await Assert.That(first.Calls).IsEqualTo(1);
        _ = await Assert.That(second.Calls).IsEqualTo(1);
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
        _ = await Assert.That(conditionInvoked).IsTrue();
        _ = await Assert.That(predicateInvoked).IsFalse();
        _ = await Assert.That(validatable.Calls).IsEqualTo(0);
        _ = await Assert.That(actual.ValidationContext).IsSameReferenceAs(context);
        _ = await Assert.That(actual.Results).IsEqualTo(results);
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