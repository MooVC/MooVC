namespace MooVC.Syntax.CSharp.BuilderTests;

using MooVC.Syntax.CSharp.Concepts;

public sealed class WhenNewIsCalled
{
    [Fact]
    public void GivenConstructTypeThenNewInstanceIsReturned()
    {
        // Arrange
        // Act
        TestConstruct first = Builder.New<TestConstruct>();
        TestConstruct second = Builder.New<TestConstruct>();

        // Assert
        _ = first.ShouldNotBeNull();
        _ = second.ShouldNotBeNull();
        _ = first.ShouldBeOfType<TestConstruct>();
        _ = second.ShouldBeOfType<TestConstruct>();
        first.ShouldNotBeSameAs(second);
    }

    private sealed class TestConstruct : Construct
    {
        public override bool IsUndefined => false;

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return Snippet.Empty;
        }
    }
}