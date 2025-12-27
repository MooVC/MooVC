namespace MooVC.Syntax.CSharp.ValidationResultExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenAndIsCalled
{
    private const string FirstMessage = "First";
    private const string SecondMessage = "Second";

    [Fact]
    public void GivenValidatableThenItsResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var additionalValidatable = new StubValidatable(new ValidationResult(SecondMessage));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(
            nameof(additionalValidatable),
            additionalValidatable);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([initial, additionalValidatable.Results.Single()]);
    }

    [Fact]
    public void GivenValidatablesThenAllResultsAreAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var firstAdditional = new StubValidatable(new ValidationResult(SecondMessage));
        var secondAdditional = new StubValidatable(new ValidationResult("Third"));
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(
            nameof(firstAdditional),
            [firstAdditional, secondAdditional]);

        // Assert
        actual.ValidationContext.ShouldBeSameAs(context);

        ValidationResult[] results = actual.Results.ToArray();
        results.ShouldBe([initial, firstAdditional.Results.Single(), secondAdditional.Results.Single()]);
    }

    [Fact]
    public void GivenPredicateThenPredicateResultIsAppended()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var additionalValidatable = new StubValidatable();
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(
            nameof(additionalValidatable),
            _ => false,
            additionalValidatable);

        // Assert
        ValidationResult[] results = actual.Results.ToArray();
        results.Length.ShouldBe(2);
        results.ShouldContain(initial);
        results.ShouldContain(result => result.MemberNames.Contains(nameof(additionalValidatable)));
    }

    [Fact]
    public void GivenPredicateAndValidatablesThenPredicateFailuresAreIncluded()
    {
        // Arrange
        var initial = new ValidationResult(FirstMessage);
        var precedingValidatable = new StubValidatable(initial);
        var firstAdditional = new StubValidatable();
        var secondAdditional = new StubValidatable();
        var context = new ValidationContext(precedingValidatable);

        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding = context.Include(
            nameof(precedingValidatable),
            precedingValidatable);

        // Act
        (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) actual = preceding.And(
            nameof(firstAdditional),
            validatable => validatable == firstAdditional,
            [firstAdditional, secondAdditional]);

        // Assert
        ValidationResult[] results = actual.Results.ToArray();
        results.Length.ShouldBe(2);
        results.ShouldContain(initial);
        results.ShouldContain(result => result.MemberNames.Contains(nameof(firstAdditional)));
        firstAdditional.Calls.ShouldBe(1);
        secondAdditional.Calls.ShouldBe(1);
    }

    private sealed class StubValidatable : IValidatableObject
    {
        public StubValidatable(params ValidationResult[] results)
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