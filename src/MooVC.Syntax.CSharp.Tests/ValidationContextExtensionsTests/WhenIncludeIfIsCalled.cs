namespace MooVC.Syntax.CSharp.ValidationContextExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenIncludeIfIsCalled
{
    private const string InitialMessage = "Initial";
    private const string Message = "Validated";

    [Fact]
    public void GivenFalseConditionThenValidationIsNotPerformed()
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
        actual.ValidationContext.ShouldBeSameAs(context);
        actual.Results.ShouldBeEmpty();
        validatable.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenTrueConditionThenValidationResultsAreReturned()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([validatable.Results.Single()]);
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenExistingResultsAndFalseConditionThenResultsAreUnchanged()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe([initial]);
        validatable.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenExistingResultsAndTrueConditionThenValidationResultsAreAppended()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe([initial, validatable.Results.Single()]);
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenMultipleValidatablesAndFalseConditionThenValidationIsNotPerformed()
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
        actual.ValidationContext.ShouldBeSameAs(context);
        actual.Results.ShouldBeEmpty();
        first.Calls.ShouldBe(0);
        second.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenMultipleValidatablesAndTrueConditionThenAllAreValidated()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([first.Results.Single(), second.Results.Single()]);
        first.Calls.ShouldBe(1);
        second.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionThenItsValueDeterminesWhetherValidationOccurs()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([validatable.Results.Single()]);
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionAndExistingResultsThenItsValueDeterminesWhetherValidationOccurs()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe([initial]);
        validatable.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenPredicateAndTrueConditionThenPredicateOutcomeAffectsResults()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(memberName);
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenPredicateAndFalseConditionThenValidationIsSkipped()
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
        predicateInvoked.ShouldBeFalse();
        validatable.Calls.ShouldBe(0);
        actual.ValidationContext.ShouldBeSameAs(context);
        actual.Results.ShouldBe(results);
    }

    [Fact]
    public void GivenPredicateAndMultipleValidatablesWhenConditionTrueThenPredicateResultsAreIncluded()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.Length.ShouldBe(2);
        combined.ShouldContain(initial);
        combined.ShouldContain(result => result.MemberNames.Contains(memberName));
        first.Calls.ShouldBe(1);
        second.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionWithPredicateWhenFalseThenValidationIsSkipped()
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
        conditionInvoked.ShouldBeTrue();
        predicateInvoked.ShouldBeFalse();
        validatable.Calls.ShouldBe(0);
        actual.ValidationContext.ShouldBeSameAs(context);
        actual.Results.ShouldBe(results);
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
