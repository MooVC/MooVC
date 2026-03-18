namespace MooVC.Syntax.Validation.ValidationResultExtensionsTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenAndIsCalled
{
    private const string FirstMessage = "First";
    private const string SecondMessage = "Second";

    [Test]
    public async Task GivenValidatableThenItsResultsAreAppended()
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
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results).IsEqualTo([initial, additionalValidatable.Results.Single()]);
    }

    [Test]
    public async Task GivenValidatablesThenAllResultsAreAppended()
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
        await Assert.That(ReferenceEquals(actual.ValidationContext, context)).IsTrue();

        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results).IsEqualTo([initial, firstAdditional.Results.Single(), secondAdditional.Results.Single()]);
    }

    [Test]
    public async Task GivenPredicateThenPredicateResultIsAppended()
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
        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results.Length).IsEqualTo(2);
        await Assert.That(results).Contains(initial);
        await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(additionalValidatable)));
    }

    [Test]
    public async Task GivenPredicateAndValidatablesThenPredicateFailuresAreIncluded()
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
        ValidationResult[] results = [.. actual.Results];
        await Assert.That(results.Length).IsEqualTo(2);
        await Assert.That(results).Contains(initial);
        await Assert.That(results).Contains(result => result.MemberNames.Contains(nameof(firstAdditional)));
        await Assert.That(firstAdditional.Calls).IsEqualTo(1);
        await Assert.That(secondAdditional.Calls).IsEqualTo(1);
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