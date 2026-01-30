namespace Mu.Modelling.State;

using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Mu.Modelling.Behavior;

public abstract record Aggregate
{
    [JsonIgnore]
    internal bool HasChanges => Propositions.Length > 0;

    [JsonPropertyName("$propositions")]
    [JsonInclude]
    internal ImmutableArray<Fact> Propositions { get; init; }

    internal Revision Revision { get; init; }
}