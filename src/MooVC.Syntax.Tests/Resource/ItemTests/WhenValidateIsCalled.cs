namespace MooVC.Syntax.Resource.ItemTests;

using System.ComponentModel.DataAnnotations;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenNoValidationErrorReturned()
    {
        // Arrange
        Item subject = Item.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenMultiLineCustomToolNamespaceThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Item
        {
            CustomToolNamespace = Snippet.From($"Line1{Environment.NewLine}Line2"),
            Location = new Path(ItemTestsData.DefaultLocationPath),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Item.CustomToolNamespace));
    }

    [Test]
    public async Task GivenEmptyLocationThenValidationErrorReturned()
    {
        // Arrange
        var subject = new Item
        {
            CustomToolNamespace = Snippet.From(ItemTestsData.DefaultCustomToolNamespace),
        };

        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsFalse();
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0].MemberNames).Contains(nameof(Item.Location));
    }

    [Test]
    public async Task GivenValidValuesThenNoValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        _ = await Assert.That(valid).IsTrue();
        _ = await Assert.That(results).IsEmpty();
    }
}