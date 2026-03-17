namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public void GivenDefaultsThenMethodsIsDefault()
    {
        // Act
        var subject = new Indexer.Methods();

        // Assert
        subject.Get.ShouldBe(Snippet.Empty);
        subject.IsDefault.ShouldBeTrue();
        subject.Set.ShouldBe(Snippet.Empty);
    }

    [Test]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var get = Snippet.From("value");
        var set = Snippet.From("value = input");

        // Act
        var subject = new Indexer.Methods
        {
            Get = get,
            Set = set,
        };

        // Assert
        subject.Get.ShouldBe(get);
        subject.IsDefault.ShouldBeFalse();
        subject.Set.ShouldBe(set);
    }
}