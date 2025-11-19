namespace MooVC.Syntax.CSharp.ValidationContextExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenIncludeIfIsCalled
{
    private const string Message = "Validated";

    [Fact]
    public void GivenFalseConditionThenValidationIsNotPerformed()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(false, validatable);

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
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(true, validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe(new[] { validatable.Results.Single() });
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenExistingResultsAndFalseConditionThenResultsAreUnchanged()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = new[] { initial };

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(false, results, validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe(new[] { initial });
        validatable.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenExistingResultsAndTrueConditionThenValidationResultsAreAppended()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = new[] { initial };

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(true, results, validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe(new[] { initial, validatable.Results.Single() });
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
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(false, new[] { first, second });

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
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(true, new[] { first, second });

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe(new[] { first.Results.Single(), second.Results.Single() });
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
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(() => true, validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe(new[] { validatable.Results.Single() });
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionAndExistingResultsThenItsValueDeterminesWhetherValidationOccurs()
    {
        // Arrange
        var validatable = new TrackingValidatable(new ValidationResult(Message));
        var context = new ValidationContext(validatable);
        var initial = new ValidationResult("Initial");
        IEnumerable<ValidationResult> results = new[] { initial };

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = context.IncludeIf(() => false, results, validatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] combined = actual.Results.ToArray();
        combined.ShouldBe(new[] { initial });
        validatable.Calls.ShouldBe(0);
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
