namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

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
            Name = DefaultMetadataName,
            Value = Snippet.From(DefaultMetadataValue),
        };
    }
}