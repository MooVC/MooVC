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

    public static readonly Name DefaultAreaName = new(DefaultAreaNameValue);
    public static readonly Name DefaultAttributeName = new(DefaultAttributeNameValue);
    public static readonly Name DefaultCompanyName = new(DefaultCompanyValue);
    public static readonly Name DefaultFactName = new(DefaultFactValue);
    public static readonly Name DefaultFeatureName = new(DefaultFeatureNameValue);
    public static readonly Name DefaultModelName = new(DefaultModelNameValue);
    public static readonly Name DefaultParameterName = new(DefaultParameterNameValue);
    public static readonly Name DefaultResultName = new(DefaultResultNameValue);
    public static readonly Name DefaultUnitName = new(DefaultUnitNameValue);
    public static readonly Name DefaultViewName = new(DefaultViewNameValue);
    public static readonly Name AlternateName = new(AlternateNameValue);

    public static Area CreateArea(Name? name = default, params Unit[] units)
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

    public static ModellingAttribute CreateAttribute(Name? name = default, Snippet? defaultValue = default, Symbol? type = default)
    {
        return new ModellingAttribute
        {
            Default = defaultValue ?? Snippet.From(DefaultSnippetValue),
            Name = name ?? DefaultAttributeName,
            Type = type ?? CreateSymbol(typeof(string)),
        };
    }

    public static Feature CreateFeature(
        Name? name = default,
        Feature.Kind? kind = default,
        Mutational? mutational = default,
        NonMutational? nonMutational = default,
        params Parameter[] parameters)
    {
        ImmutableArray<Parameter> parameterArray = parameters.Length == 0
            ? []
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

    public static Model CreateModel(Name? company = default, Name? name = default, params Area[] areas)
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

    public static Mutational CreateMutational(Name? fact = default, Mutational.Kind? kind = default)
    {
        return new Mutational
        {
            Fact = fact ?? DefaultFactName,
            Type = kind ?? Mutational.Kind.Creational,
        };
    }

    public static NonMutational CreateNonMutational(Name? view = default, NonMutational.Kind? kind = default)
    {
        return new NonMutational
        {
            Source = kind ?? NonMutational.Kind.ReadStore,
            View = new View { Name = view ?? DefaultViewName },
        };
    }

    public static Parameter CreateParameter(Name? name = default, Snippet? defaultValue = default, Symbol? type = default)
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

    public static Result CreateResult(Name? name = default, Symbol? type = default)
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

    public static Unit CreateUnit(
        Name? name = default,
        ImmutableArray<ModellingAttribute>? attributes = default,
        ImmutableArray<Feature>? features = default,
        ImmutableArray<View>? views = default)
    {
        ImmutableArray<ModellingAttribute> attributeArray = attributes ?? [];
        ImmutableArray<Feature> featureArray = features ?? [];
        ImmutableArray<View> viewArray = views ?? [];

        return new Unit
        {
            Attributes = attributeArray,
            Features = featureArray,
            Name = name ?? DefaultUnitName,
            Views = viewArray,
        };
    }

    public static View CreateView(
        Name? name = default,
        ImmutableArray<ModellingAttribute>? attributes = default,
        ImmutableArray<Qualifier>? facts = default)
    {
        ImmutableArray<ModellingAttribute> attributeArray = attributes ?? [];
        ImmutableArray<Qualifier> factArray = facts ?? [];

        return new View
        {
            Attributes = attributeArray,
            Facts = factArray,
            Name = name ?? DefaultViewName,
        };
    }

    public static Name CreateAlternateName()
    {
        return AlternateName;
    }
}