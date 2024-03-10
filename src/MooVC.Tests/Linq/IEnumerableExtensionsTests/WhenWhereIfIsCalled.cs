namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenWhereIfIsCalled
{
    [Fact]
    public void GivenAFailingConditionThenThePredicateIsNotApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithCondition(false);

        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenAConditionIsSpecifiedThenTheEnumerationIsReturnedWithoutEvaluatingTheConditionOrThePredicate()
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

        _ = result.Should().BeNull();
        _ = wasEvaluated.Should().BeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenApplicabilityIsSpecifiedThenTheEnumerationIsReturnedWithoutInvokingThePredicate()
    {
        IEnumerable<int>? enumeration = default;
        bool wasEvaluated = false;

        bool Predicate(int value)
        {
            return wasEvaluated = true;
        }

        IEnumerable<int>? result = enumeration
            .WhereIf(true, Predicate);

        _ = result.Should().BeNull();
        _ = wasEvaluated.Should().BeFalse();
    }

    [Fact]
    public void GivenAPassingConditionThenThePredicateIsApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithCondition(true);

        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public void GivenFailingApplicabilityThenThePredicateIsNotApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(false);

        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public void GivenPassingApplicabilityThenThePredicateIsApplied()
    {
        bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(true);

        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public void GivenNonEmptyEnumerationAndPassingConditionThenFilteredEnumerationIsReturned()
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
        _ = result.Should().Equal(2, 4);
    }

    [Fact]
    public void GivenNonEmptyEnumerationAndFailingConditionThenUnfilteredEnumerationIsReturned()
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
        _ = result.Should().Equal(1, 2, 3, 4, 5);
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