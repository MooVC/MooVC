namespace Mu.Modelling.NonMutationalTests;

using MooVC.Syntax.Elements;

public sealed class WhenUsingIsCalled
{
    private const string UpdatedViewValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        NonMutational original = ModellingTestData.CreateNonMutational();
        var updated = new View { Name = UpdatedViewValue };

        // Act
        NonMutational result = original.Using(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.View.ShouldBe(updated);
        result.Source.ShouldBe(original.Source);
    }
}