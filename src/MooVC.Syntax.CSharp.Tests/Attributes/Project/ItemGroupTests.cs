namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenItemGroupIsUndefined()
    {
        // Act
        var subject = new ItemGroup();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Items.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Item item = ItemGroupTestsData.CreateItem();

        // Act
        var subject = new ItemGroup
        {
            Condition = Snippet.From(ItemGroupTestsData.DefaultCondition),
            Label = Snippet.From(ItemGroupTestsData.DefaultLabel),
            Items = [item],
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(ItemGroupTestsData.DefaultCondition));
        subject.Label.ShouldBe(Snippet.From(ItemGroupTestsData.DefaultLabel));
        subject.Items.ShouldBe(new[] { item });
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        ItemGroup subject = ItemGroup.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(ItemGroup.Condition));
    }

    [Fact]
    public void GivenUndefinedItemThenValidationErrorReturned()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create(item: Item.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(ItemGroup.Items));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        ItemGroup subject = ItemGroup.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Item item = ItemGroupTestsData.CreateItem();
        ItemGroup subject = ItemGroupTestsData.Create(item: item);

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Include), ItemGroupTestsData.DefaultInclude));

        var element = new XElement(
            nameof(ItemGroup),
            new XAttribute(nameof(ItemGroup.Condition), ItemGroupTestsData.DefaultCondition),
            new XAttribute(nameof(ItemGroup.Label), ItemGroupTestsData.DefaultLabel),
            itemElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithItemsIsCalled
{
    [Fact]
    public void GivenItemsThenReturnsUpdatedInstance()
    {
        // Arrange
        Item existing = ItemGroupTestsData.CreateItem();
        Item additional = new Item { Include = Snippet.From("Extra") };
        ItemGroup original = ItemGroupTestsData.Create(item: existing);

        // Act
        ItemGroup result = original.WithItems(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Items.ShouldBe(original.Items.Concat(new[] { additional }));
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
    }
}

public sealed class WhenEqualsItemGroupIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        object other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorItemGroupItemGroupIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        ItemGroup? left = default;
        ItemGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorItemGroupItemGroupIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create();

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
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class ItemGroupTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultInclude = "Include";
    public const string DefaultLabel = "Label";

    public static ItemGroup Create(
        Snippet? condition = default,
        Snippet? label = default,
        Item? item = default)
    {
        var values = new ItemGroup
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
        };

        if (item is not null)
        {
            values = values.WithItems(item);
        }

        return values;
    }

    public static Item CreateItem()
    {
        return new Item
        {
            Include = Snippet.From(DefaultInclude),
        };
    }
}