namespace Mu.Modelling.NonMutationalTests;

public sealed class WhenFromIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        NonMutational original = ModellingTestData.CreateNonMutational();

        // Act
        NonMutational result = original.From(NonMutational.Kind.WriteStore);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Source.ShouldBe(NonMutational.Kind.WriteStore);
        result.View.ShouldBe(original.View);
    }
}