namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(id: Guid.Parse("F247F4D5-5BC0-4BA2-BF12-9C5D052A3AB5"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}