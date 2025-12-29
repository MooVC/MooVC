namespace MooVC.Syntax.CSharp.Attributes.Project.ItemTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenItemIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Exclude.ShouldBe(Snippet.Empty);
        subject.Include.ShouldBe(Snippet.Empty);
        subject.KeepDuplicates.ShouldBeFalse();
        subject.MatchOnMetadata.ShouldBe(Snippet.Empty);
        subject.MatchOnMetadataOptions.ShouldBe(Snippet.Empty);
        subject.Metadata.ShouldBeEmpty();
        subject.Remove.ShouldBe(Snippet.Empty);
        subject.RemoveMetadata.ShouldBe(Snippet.Empty);
        subject.Update.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Metadata metadata = ItemTestsData.CreateMetadata();

        // Act
        var subject = new Item
        {
            Condition = Snippet.From(ItemTestsData.DefaultCondition),
            Exclude = Snippet.From(ItemTestsData.DefaultExclude),
            Include = Snippet.From(ItemTestsData.DefaultInclude),
            KeepDuplicates = true,
            MatchOnMetadata = Snippet.From(ItemTestsData.DefaultMatchOnMetadata),
            MatchOnMetadataOptions = Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions),
            Metadata = [metadata],
            Remove = Snippet.From(ItemTestsData.DefaultRemove),
            RemoveMetadata = Snippet.From(ItemTestsData.DefaultRemoveMetadata),
            Update = Snippet.From(ItemTestsData.DefaultUpdate),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(ItemTestsData.DefaultCondition));
        subject.Exclude.ShouldBe(Snippet.From(ItemTestsData.DefaultExclude));
        subject.Include.ShouldBe(Snippet.From(ItemTestsData.DefaultInclude));
        subject.KeepDuplicates.ShouldBeTrue();
        subject.MatchOnMetadata.ShouldBe(Snippet.From(ItemTestsData.DefaultMatchOnMetadata));
        subject.MatchOnMetadataOptions.ShouldBe(Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions));
        subject.Metadata.ShouldBe(new[] { metadata });
        subject.Remove.ShouldBe(Snippet.From(ItemTestsData.DefaultRemove));
        subject.RemoveMetadata.ShouldBe(Snippet.From(ItemTestsData.DefaultRemoveMetadata));
        subject.Update.ShouldBe(Snippet.From(ItemTestsData.DefaultUpdate));
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Item subject = Item.Undefined;
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
        Item subject = ItemTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Condition));
    }

    [Fact]
    public void GivenUndefinedMetadataThenValidationErrorReturned()
    {
        // Arrange
        Item subject = ItemTestsData.Create(metadata: Metadata.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Item.Metadata));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Item subject = Item.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Metadata metadata = ItemTestsData.CreateMetadata();
        Item subject = ItemTestsData.Create(metadata: metadata, keepDuplicates: true);

        var element = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Condition), ItemTestsData.DefaultCondition),
            new XAttribute(nameof(Item.Exclude), ItemTestsData.DefaultExclude),
            new XAttribute(nameof(Item.Include), ItemTestsData.DefaultInclude),
            new XAttribute(nameof(Item.KeepDuplicates), true.ToString().ToLowerInvariant()),
            new XAttribute(nameof(Item.MatchOnMetadata), ItemTestsData.DefaultMatchOnMetadata),
            new XAttribute(nameof(Item.MatchOnMetadataOptions), ItemTestsData.DefaultMatchOnMetadataOptions),
            new XAttribute(nameof(Item.Remove), ItemTestsData.DefaultRemove),
            new XAttribute(nameof(Item.RemoveMetadata), ItemTestsData.DefaultRemoveMetadata),
            new XAttribute(nameof(Item.Update), ItemTestsData.DefaultUpdate),
            new XElement(metadata.Name.ToXmlElementName(),
                new XAttribute(nameof(Metadata.Condition), ItemTestsData.DefaultMetadataCondition),
                ItemTestsData.DefaultMetadataValue));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithMetadataIsCalled
{
    [Fact]
    public void GivenMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata existing = ItemTestsData.CreateMetadata();
        Metadata additional = new Metadata
        {
            Name = new Identifier("Other"),
            Value = Snippet.From("Value"),
        };

        Item original = ItemTestsData.Create(metadata: existing);

        // Act
        Item result = original.WithMetadata(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Metadata.ShouldBe(original.Metadata.Concat(new[] { additional }));
        result.Condition.ShouldBe(original.Condition);
        result.Include.ShouldBe(original.Include);
    }
}

public sealed class WhenEqualsItemIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item other = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item other = ItemTestsData.Create(include: Snippet.From("Other"));

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
        Item subject = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        object other = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorItemItemIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Item? left = default;
        Item? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorItemItemIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

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
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create();

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
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class ItemTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultExclude = "Exclude";
    public const string DefaultInclude = "Include";
    public const string DefaultMatchOnMetadata = "MatchOnMetadata";
    public const string DefaultMatchOnMetadataOptions = "MatchOnMetadataOptions";
    public const string DefaultRemove = "Remove";
    public const string DefaultRemoveMetadata = "RemoveMetadata";
    public const string DefaultUpdate = "Update";
    public const string DefaultMetadataCondition = "MetadataCondition";
    public const string DefaultMetadataName = "MetadataName";
    public const string DefaultMetadataValue = "MetadataValue";

    public static Item Create(
        Snippet? condition = default,
        Snippet? exclude = default,
        Snippet? include = default,
        bool keepDuplicates = false,
        Snippet? matchOnMetadata = default,
        Snippet? matchOnMetadataOptions = default,
        Metadata? metadata = default,
        Snippet? remove = default,
        Snippet? removeMetadata = default,
        Snippet? update = default)
    {
        var values = new Item
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Exclude = exclude ?? Snippet.From(DefaultExclude),
            Include = include ?? Snippet.From(DefaultInclude),
            KeepDuplicates = keepDuplicates,
            MatchOnMetadata = matchOnMetadata ?? Snippet.From(DefaultMatchOnMetadata),
            MatchOnMetadataOptions = matchOnMetadataOptions ?? Snippet.From(DefaultMatchOnMetadataOptions),
            Remove = remove ?? Snippet.From(DefaultRemove),
            RemoveMetadata = removeMetadata ?? Snippet.From(DefaultRemoveMetadata),
            Update = update ?? Snippet.From(DefaultUpdate),
        };

        if (metadata is not null)
        {
            values = values.WithMetadata(metadata);
        }

        return values;
    }

    public static Metadata CreateMetadata()
    {
        return new Metadata
        {
            Condition = Snippet.From(DefaultMetadataCondition),
            Name = new Identifier(DefaultMetadataName),
            Value = Snippet.From(DefaultMetadataValue),
        };
    }
}