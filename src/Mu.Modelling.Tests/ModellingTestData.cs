namespace Mu.Modelling;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

internal static class ModellingTestData
{
    public const string DefaultAreaNameValue = "Area";
    public const string DefaultAttributeNameValue = "Attribute";
    public const string DefaultCompanyValue = "Company";
    public const string DefaultFactValue = "Fact";
    public const string DefaultFeatureNameValue = "Feature";
    public const string DefaultModelNameValue = "Model";
    public const string DefaultParameterNameValue = "Parameter";
    public const string DefaultQualifierValue = "Mu.Modelling.Fact";
    public const string DefaultResultNameValue = "Result";
    public const string DefaultSnippetValue = "Value";
    public const string DefaultUnitNameValue = "Unit";
    public const string DefaultViewNameValue = "View";
    public const string AlternateNameValue = "Alternate";

    public static readonly Identifier DefaultAreaName = new(DefaultAreaNameValue);
    public static readonly Identifier DefaultAttributeName = new(DefaultAttributeNameValue);
    public static readonly Identifier DefaultCompanyName = new(DefaultCompanyValue);
    public static readonly Identifier DefaultFactName = new(DefaultFactValue);
    public static readonly Identifier DefaultFeatureName = new(DefaultFeatureNameValue);
    public static readonly Identifier DefaultModelName = new(DefaultModelNameValue);
    public static readonly Identifier DefaultParameterName = new(DefaultParameterNameValue);
    public static readonly Identifier DefaultResultName = new(DefaultResultNameValue);
    public static readonly Identifier DefaultUnitName = new(DefaultUnitNameValue);
    public static readonly Identifier DefaultViewName = new(DefaultViewNameValue);
    public static readonly Identifier AlternateName = new(AlternateNameValue);

    public static Area CreateArea(Identifier? name = default, params Unit[] units)
    {
        ImmutableArray<Unit> unitArray = units.Length == 0
            ? []
            : ImmutableArray.Create(units);

        return new Area
        {
            Name = name ?? DefaultAreaName,
            Units = unitArray,
        };
    }

    public static ModellingAttribute CreateAttribute(Identifier? name = default, Snippet? defaultValue = default, Symbol? type = default)
    {
        return new ModellingAttribute
        {
            Default = defaultValue ?? Snippet.From(DefaultSnippetValue),
            Name = name ?? DefaultAttributeName,
            Type = type ?? CreateSymbol(typeof(string)),
        };
    }

    public static Feature CreateFeature(Identifier? name = default, Feature.Kind? kind = default, Mutational? mutational = default, NonMutational? nonMutational = default, params Parameter[] parameters)
    {
        ImmutableArray<Parameter> parameterArray = parameters.Length == 0
            ? ImmutableArray<Parameter>.Empty
            : ImmutableArray.Create(parameters);

        return new Feature
        {
            Mutational = mutational ?? CreateMutational(),
            Name = name ?? DefaultFeatureName,
            NonMutational = nonMutational ?? CreateNonMutational(),
            Parameters = parameterArray,
            Results = [],
            Type = kind ?? Feature.Kind.Mutational,
        };
    }

    public static Identifier CreateIdentifier(string value)
    {
        return new Identifier(value);
    }

    public static Model CreateModel(Identifier? company = default, Identifier? name = default, params Area[] areas)
    {
        ImmutableArray<Area> areaArray = areas.Length == 0
            ? []
            : ImmutableArray.Create(areas);

        return new Model
        {
            Areas = areaArray,
            Company = company ?? DefaultCompanyName,
            Name = name ?? DefaultModelName,
        };
    }

    public static Mutational CreateMutational(Identifier? fact = default, Mutational.Kind? kind = default)
    {
        return new Mutational
        {
            Fact = fact ?? DefaultFactName,
            Type = kind ?? Mutational.Kind.Creational,
        };
    }

    public static NonMutational CreateNonMutational(Identifier? view = default, NonMutational.Kind? kind = default)
    {
        return new NonMutational
        {
            Source = kind ?? NonMutational.Kind.ReadStore,
            View = view ?? DefaultViewName,
        };
    }

    public static Parameter CreateParameter(Identifier? name = default, Snippet? defaultValue = default, Symbol? type = default)
    {
        return new Parameter
        {
            Default = defaultValue ?? Snippet.From(DefaultSnippetValue),
            Name = name ?? DefaultParameterName,
            Type = type ?? CreateSymbol(typeof(int)),
        };
    }

    public static Qualifier CreateQualifier(string value = DefaultQualifierValue)
    {
        return value;
    }

    public static Result CreateResult(Identifier? name = default, Symbol? type = default)
    {
        return new Result
        {
            Name = name ?? DefaultResultName,
            Type = type ?? CreateSymbol(typeof(string)),
        };
    }

    public static Symbol CreateSymbol(Type type)
    {
        return type;
    }

    public static Unit CreateUnit(Identifier? name = default, ImmutableArray<ModellingAttribute>? attributes = default, ImmutableArray<Feature>? features = default, ImmutableArray<View>? views = default)
    {
        ImmutableArray<ModellingAttribute> attributeArray = attributes ?? ImmutableArray<ModellingAttribute>.Empty;
        ImmutableArray<Feature> featureArray = features ?? ImmutableArray<Feature>.Empty;
        ImmutableArray<View> viewArray = views ?? ImmutableArray<View>.Empty;

        return new Unit
        {
            Attributes = attributeArray,
            Features = featureArray,
            Name = name ?? DefaultUnitName,
            Views = viewArray,
        };
    }

    public static View CreateView(Identifier? name = default, ImmutableArray<ModellingAttribute>? attributes = default, ImmutableArray<Qualifier>? facts = default)
    {
        ImmutableArray<ModellingAttribute> attributeArray = attributes ?? ImmutableArray<ModellingAttribute>.Empty;
        ImmutableArray<Qualifier> factArray = facts ?? ImmutableArray<Qualifier>.Empty;

        return new View
        {
            Attributes = attributeArray,
            Facts = factArray,
            Name = name ?? DefaultViewName,
        };
    }

    public static Identifier CreateAlternateName()
    {
        return AlternateName;
    }
}