namespace Mu.Modelling;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

internal static class ModellingTestData
{
    private const string DefaultAreaNameValue = "Area";
    private const string DefaultAttributeNameValue = "Attribute";
    private const string DefaultCompanyValue = "Company";
    private const string DefaultFactValue = "Fact";
    private const string DefaultFeatureNameValue = "Feature";
    private const string DefaultModelNameValue = "Model";
    private const string DefaultParameterNameValue = "Parameter";
    private const string DefaultQualifierValue = "Mu.Modelling.Fact";
    private const string DefaultResultNameValue = "Result";
    private const string DefaultSnippetValue = "Value";
    private const string DefaultUnitNameValue = "Unit";
    private const string DefaultViewNameValue = "View";
    private const string AlternateNameValue = "Alternate";

    private static readonly Identifier DefaultAreaName = new(DefaultAreaNameValue);
    private static readonly Identifier DefaultAttributeName = new(DefaultAttributeNameValue);
    private static readonly Identifier DefaultCompanyName = new(DefaultCompanyValue);
    private static readonly Identifier DefaultFactName = new(DefaultFactValue);
    private static readonly Identifier DefaultFeatureName = new(DefaultFeatureNameValue);
    private static readonly Identifier DefaultModelName = new(DefaultModelNameValue);
    private static readonly Identifier DefaultParameterName = new(DefaultParameterNameValue);
    private static readonly Identifier DefaultResultName = new(DefaultResultNameValue);
    private static readonly Identifier DefaultUnitName = new(DefaultUnitNameValue);
    private static readonly Identifier DefaultViewName = new(DefaultViewNameValue);
    private static readonly Identifier AlternateName = new(AlternateNameValue);


    public static Area CreateArea(Identifier? name = null, params Unit[] units)
    {
        ImmutableArray<Unit> unitArray = units.Length == 0
            ? ImmutableArray<Unit>.Empty
            : ImmutableArray.Create(units);

        return new Area
        {
            Name = name ?? DefaultAreaName,
            Units = unitArray,
        };
    }

    public static ModellingAttribute CreateAttribute(Identifier? name = null, Snippet? defaultValue = null, Symbol? type = null)
    {
        return new ModellingAttribute
        {
            Default = defaultValue ?? Snippet.From(DefaultSnippetValue),
            Name = name ?? DefaultAttributeName,
            Type = type ?? CreateSymbol(typeof(string)),
        };
    }

    public static Feature CreateFeature(Identifier? name = null, Feature.Kind? kind = null, Mutational? mutational = null, NonMutational? nonMutational = null, params Parameter[] parameters)
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
            Results = ImmutableArray<Result>.Empty,
            Type = kind ?? Feature.Kind.Mutational,
        };
    }

    public static Identifier CreateIdentifier(string value)
    {
        return new Identifier(value);
    }

    public static Model CreateModel(Identifier? company = null, Identifier? name = null, params Area[] areas)
    {
        ImmutableArray<Area> areaArray = areas.Length == 0
            ? ImmutableArray<Area>.Empty
            : ImmutableArray.Create(areas);

        return new Model
        {
            Areas = areaArray,
            Company = company ?? DefaultCompanyName,
            Name = name ?? DefaultModelName,
        };
    }

    public static Mutational CreateMutational(Identifier? fact = null, Mutational.Kind? kind = null)
    {
        return new Mutational
        {
            Fact = fact ?? DefaultFactName,
            Type = kind ?? Mutational.Kind.Creational,
        };
    }

    public static NonMutational CreateNonMutational(Identifier? view = null, NonMutational.Kind? kind = null)
    {
        return new NonMutational
        {
            Source = kind ?? NonMutational.Kind.ReadStore,
            View = view ?? DefaultViewName,
        };
    }

    public static Parameter CreateParameter(Identifier? name = null, Snippet? defaultValue = null, Symbol? type = null)
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

    public static Result CreateResult(Identifier? name = null, Symbol? type = null)
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

    public static Unit CreateUnit(Identifier? name = null, ImmutableArray<ModellingAttribute>? attributes = null, ImmutableArray<Feature>? features = null, ImmutableArray<View>? views = null)
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

    public static View CreateView(Identifier? name = null, ImmutableArray<ModellingAttribute>? attributes = null, ImmutableArray<Qualifier>? facts = null)
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