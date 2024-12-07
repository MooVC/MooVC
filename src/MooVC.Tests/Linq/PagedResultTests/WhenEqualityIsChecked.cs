namespace MooVC.Linq.PagedResultTests;

public sealed class WhenEqualityIsChecked
{
    [Fact]
    public void GivenTwoInstancesWithDifferentRequestsThenNotEqual()
    {
        // Arrange
        var request1 = new Paging(page: 1, size: 10);
        var request2 = new Paging(page: 2, size: 10);
        string[] values = ["Test1", "Test2"];
        var result1 = new PagedResult<string>(request1, values);
        var result2 = new PagedResult<string>(request2, values);

        // Act
        bool areEqual = result1.Equals(result2);
        bool operatorEqual = result1 == result2;
        bool operatorNotEqual = result1 != result2;

        // Assert
        _ = areEqual.Should().BeFalse();
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenTwoIdenticalInstancesThenEqual()
    {
        // Arrange
        var request = new Paging(page: 1, size: 10);
        string[] values = ["Test1", "Test2"];
        var result1 = new PagedResult<string>(request, values);
        var result2 = new PagedResult<string>(request, values);

        // Act
        bool areEqual = result1.Equals(result2);
        bool operatorEqual = result1 == result2;
        bool operatorNotEqual = result1 != result2;

        // Assert
        _ = areEqual.Should().BeTrue();
        _ = operatorEqual.Should().BeTrue();
        _ = operatorNotEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenAnInstanceAndNullThenNotEqual()
    {
        // Arrange
        var request = new Paging(page: 1, size: 10);
        string[] values = ["Test1", "Test2"];
        var result1 = new PagedResult<string>(request, values);
        PagedResult<string>? result2 = default;

        // Act
        bool operatorEqual = result1 == result2;
        bool operatorNotEqual = result1 != result2;

        // Assert
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenTwoInstancesWithDifferentValuesThenNotEqual()
    {
        // Arrange
        var request = new Paging(page: 1, size: 10);
        string[] values1 = ["Test1", "Test2"];
        string[] values2 = ["Test3", "Test4"];
        var result1 = new PagedResult<string>(request, values1);
        var result2 = new PagedResult<string>(request, values2);

        // Act
        bool areEqual = result1.Equals(result2);
        bool operatorEqual = result1 == result2;
        bool operatorNotEqual = result1 != result2;

        // Assert
        _ = areEqual.Should().BeFalse();
        _ = operatorEqual.Should().BeFalse();
        _ = operatorNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenTwoInstancesWithSameValuesButDifferentOrdersThenNotEqual()
    {
        // Arrange
        var request = new Paging(page: 1, size: 10);
        string[] values1 = ["Test1", "Test2"];
        string[] values2 = ["Test2", "Test1"];
        var result1 = new PagedResult<string>(request, values1);
        var result2 = new PagedResult<string>(request, values2);

        // Act
        bool areEqual = result1.Equals(result2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoIdenticalInstancesThenSameHashCode()
    {
        // Arrange
        var request = new Paging(page: 1, size: 10);
        string[] values = ["Test1", "Test2"];
        var result1 = new PagedResult<string>(request, values);
        var result2 = new PagedResult<string>(request, values);

        // Act
        int hashCode1 = result1.GetHashCode();
        int hashCode2 = result2.GetHashCode();

        // Assert
        _ = hashCode1.Should().Be(hashCode2);
    }
}