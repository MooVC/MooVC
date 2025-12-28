namespace MooVC.Syntax.CSharp.BuilderTests;

using MooVC.Syntax.CSharp.Concepts;

public sealed class WhenNewIsCalled
{
    [Fact]
    public void GivenConstructTypeThenNewInstanceIsReturned()
    {
        // Arrange
        // Act
        TestType first = Builder.New<TestType>();
        TestType second = Builder.New<TestType>();

        // Assert
        _ = first.ShouldNotBeNull();
        _ = second.ShouldNotBeNull();
        _ = first.ShouldBeOfType<TestType>();
        _ = second.ShouldBeOfType<TestType>();
        first.ShouldNotBeSameAs(second);
    }

    private sealed class TestType
        : Type
    {
        public override bool IsUndefined => false;

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return Snippet.Empty;
        }
    }
}