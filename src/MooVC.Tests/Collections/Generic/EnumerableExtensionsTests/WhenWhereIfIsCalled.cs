namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenWhereIfIsCalled
    {
        [Fact]
        public void GivenAFailingConditionThenThePredicateIsNotApplied()
        {
            bool wasInvoked = VerifyPredicateInvocationWithCondition(false);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenAPassingConditionThenThePredicateIsApplied()
        {
            bool wasInvoked = VerifyPredicateInvocationWithCondition(true);

            Assert.True(wasInvoked);
        }

        [Fact]
        public void GivenFailingApplicabilityThenThePredicateIsNotApplied()
        {
            bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(false);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenPassingApplicabilityThenThePredicateIsNotApplied()
        {
            bool wasInvoked = VerifyPredicateInvocationWithExplicitApplicability(true);

            Assert.True(wasInvoked);
        }

        private bool VerifyPredicateInvocation(Func<IEnumerable<int>, Func<int, bool>, IEnumerable<int>> invocation)
        {
            bool wasInvoked = false;
            int[] enumeration = new[] { 1, 2, 3 };

            bool Predicate(int value)
            {
                wasInvoked = true;

                return wasInvoked;
            }

            IEnumerable<int> result = invocation(enumeration, Predicate);

            _ = result.ToArray();

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
}