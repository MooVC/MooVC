namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenWhereIfIsCalled
{
    [Test]
    public async Task GivenAFailingConditionThenThePredicateIsNotApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithCondition(false);

        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
    public async Task GivenANullEnumerationWhenAConditionIsSpecifiedThenTheEnumerationIsReturnedWithoutEvaluatingTheConditionOrThePredicate()
    {
        IEnumerable<int>? enumeration = default;
        bool wasEvaluated = false;

        bool Condition()
        {
            return wasEvaluated = true;
        }

        bool Predicate(int value)
        {
            return wasEvaluated = true;
        }

        IEnumerable<int>? result = enumeration
            .WhereIf(Condition, Predicate);

        _ = await Assert.That(result).IsNull();
        _ = await Assert.That(wasEvaluated).IsFalse();
    }

    [Test]
    public async Task GivenANullEnumerationWhenApplicabilityIsSpecifiedThenTheEnumerationIsReturnedWithoutInvokingThePredicate()
    {
        IEnumerable<int>? enumeration = default;
        bool wasEvaluated = false;

        bool Predicate(int value)
        {
            return wasEvaluated = true;
        }

        IEnumerable<int>? result = enumeration
            .WhereIf(true, Predicate);

        _ = await Assert.That(result).IsNull();
        _ = await Assert.That(wasEvaluated).IsFalse();
    }

    [Test]
    public async Task GivenAPassingConditionThenThePredicateIsApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithCondition(true);

        _ = await Assert.That(wasInvoked).IsTrue();
    }

    [Test]
    public async Task GivenFailingApplicabilityThenThePredicateIsNotApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(false);

        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
    public async Task GivenNonEmptyEnumerationAndFailingConditionThenUnfilteredEnumerationIsReturned()
    {
        // Arrange
        int[] enumeration = [1, 2, 3, 4, 5];

        static bool Predicate(int value)
        {
            return value % 2 == 0;
        }

        // Act
        IEnumerable<int>? result = enumeration.WhereIf(() => false, Predicate);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo([1, 2, 3, 4, 5]);
    }

    [Test]
    public async Task GivenNonEmptyEnumerationAndPassingConditionThenFilteredEnumerationIsReturned()
    {
        // Arrange
        int[] enumeration = [1, 2, 3, 4, 5];

        static bool Predicate(int value)
        {
            return value % 2 == 0;
        }

        // Act
        IEnumerable<int>? result = enumeration.WhereIf(() => true, Predicate);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo([2, 4]);
    }

    [Test]
    public async Task GivenPassingApplicabilityThenThePredicateIsApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(true);

        _ = await Assert.That(wasInvoked).IsTrue();
    }

    private bool VerifyPredicateInvocation(Func<IEnumerable<int>, Func<int, bool>, IEnumerable<int>?> invocation)
    {
        bool wasInvoked = false;
        int[] enumeration = [1, 2, 3];

        bool Predicate(int value)
        {
            wasInvoked = true;

            return wasInvoked;
        }

        IEnumerable<int>? result = invocation(enumeration, Predicate);

        _ = result.ToArrayOrEmpty();

        return wasInvoked;
    }

    private bool VerifyPredicateInvocationWithCondition(bool isPassing)
    {
        return VerifyPredicateInvocation((enumeration, predicate) => enumeration.WhereIf(() => isPassing, predicate));
    }

    private bool VerifyPredicateInvocationWithExplicitApplicability(bool isPassing)
    {
        return VerifyPredicateInvocation((enumeration, predicate) => enumeration.WhereIf(isPassing, predicate));
    }
}