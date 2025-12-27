namespace MooVC.Syntax.CSharp.BuilderTests;

public sealed class WhenNewIsCalled
{
    [Fact]
    public void GivenConstructTypeThenNewInstanceIsReturned()
    {
        // Arrange
        // Act
        var first = Builder.New<TestConstruct>();
        var second = Builder.New<TestConstruct>();

        // Assert
        first.ShouldNotBeNull();
        second.ShouldNotBeNull();
        first.ShouldBeOfType<TestConstruct>();
        second.ShouldBeOfType<TestConstruct>();
        first.ShouldNotBeSameAs(second);
    }

    private sealed class TestConstruct : Concepts.Construct
    {
        public override bool IsUndefined => false;

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return Snippet.Empty;
        }
    }
}
