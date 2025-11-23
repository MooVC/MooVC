namespace MooVC.Syntax.CSharp.ValidationResultExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenAndIfIsCalled
{
    private const string Message = "Validated";

    [Fact]
    public void GivenFalseConditionThenPrecedingResultIsReturned()
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
        actual.ShouldBe(preceding);
        validatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenTrueConditionThenValidationIsAppended()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([initial, additionalValidatable.Results.Single()]);
        precedingValidatable.Calls.ShouldBe(1);
        additionalValidatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFalseConditionAndMultipleValidatablesThenPrecedingResultIsReturned()
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
        actual.ShouldBe(preceding);
        precedingValidatable.Calls.ShouldBe(1);
        firstAdditional.Calls.ShouldBe(0);
        secondAdditional.Calls.ShouldBe(0);
    }

    [Fact]
    public void GivenTrueConditionAndMultipleValidatablesThenValidationIsAppended()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([initial, firstAdditional.Results.Single(), secondAdditional.Results.Single()]);
        precedingValidatable.Calls.ShouldBe(1);
        firstAdditional.Calls.ShouldBe(1);
        secondAdditional.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionThenItDeterminesWhetherValidationOccurs()
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
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([initial, additionalValidatable.Results.Single()]);
        precedingValidatable.Calls.ShouldBe(1);
        additionalValidatable.Calls.ShouldBe(1);
    }

    [Fact]
    public void GivenFunctionConditionAndValidatablesThenItDeterminesWhetherValidationOccurs()
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
        actual.ShouldBe(preceding);
        precedingValidatable.Calls.ShouldBe(1);
        additionalValidatable.Calls.ShouldBe(0);
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