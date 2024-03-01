namespace MooVC.Generators.Data;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Generates implementation elements for IFeature within an class or record that declares that it is an implementation.
/// Also generates an extension that supports consumption of the Feature through the prefix "With".
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed partial class FeatureGenerator
    : IIncrementalGenerator
{
    private const string TypeName = "IFeature";
    private static readonly Dictionary<string, Attribute> cache = [];

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<IEnumerable<Feature>> declarations = context
            .SyntaxProvider
            .CreateSyntaxProvider(IsMatch, Transform)
            .Collect()
            .Select(static (collections, _) => collections.SelectMany(models => models));

        context.RegisterImplementationSourceOutput(declarations, Generate);
    }

    private static void Generate(SourceProductionContext context, IEnumerable<Feature> features)
    {
        foreach (IGrouping<Attribute, Feature> attribute in features.GroupBy(feature => feature.Attribute))
        {
            foreach (Feature feature in attribute.Where(feature => feature.HasProperty))
            {
                GenerateProperty(context, feature);
            }

            if (!attribute.Key.HasExtension)
            {
                if (attribute.Key.HasDefaultConstructor)
                {
                    GenerateMutatorExtension(attribute.Key, context);
                }

                GenerateInstanceExtension(attribute.Key, context);
            }
        }
    }

    private static void GenerateExtension(Attribute attribute, SourceProductionContext context, string name, string method)
    {
        string content = $$"""
            namespace {{attribute.Namespace}};

            using MooVC;
            using MooVC.Data;
            
            public static partial class {{attribute.Name}}Extensions
            {
            {{method}}
            }
            """;

        context.AddSource($"{attribute.Namespace}.{attribute.Name}Extensions.With{attribute.Name}.{name}.g.cs", content);
    }

    private static void GenerateInstanceExtension(Attribute attribute, SourceProductionContext context)
    {
        string content = $$"""
                public static T With{{attribute.Name}}<T>(this T subject, {{attribute.Name}} attribute)
                    where T : IFeature<{{attribute.Name}}>
                {
                    return subject.With<{{attribute.Name}}, T>(attribute);
                }
            """;

        GenerateExtension(attribute, context, "Instance", content);
    }

    private static void GenerateMutatorExtension(Attribute attribute, SourceProductionContext context)
    {
        string content = $$"""
                public static T With{{attribute.Name}}<T>(this T subject, Mutator<{{attribute.Name}}> attribute)
                    where T : IFeature<{{attribute.Name}}>
                {
                    return subject.With<{{attribute.Name}}, T>(attribute);
                }
            """;

        GenerateExtension(attribute, context, "Mutator", content);
    }

    private static void GenerateProperty(SourceProductionContext context, Feature feature)
    {
        string content = $$"""
            namespace {{feature.Namespace}};

            using {{feature.Attribute.Namespace}};
            using MooVC.Data;

            partial {{feature.Type}} {{feature.Name}}
            {
                {{feature.Attribute.Name}} IFeature<{{feature.Attribute.Name}}>.Attribute { get; set; }
            }
            """;

        context.AddSource($"{feature.Namespace}.{feature.Name}.{feature.Attribute.Name}.g.cs", content);
    }

    private static bool HasDefaultConstructor(ITypeSymbol feature)
    {
        if (feature.IsAbstract)
        {
            return false;
        }

        IMethodSymbol[] constructors = feature
            .GetMembers()
            .OfType<IMethodSymbol>()
            .Where(method => method.MethodKind == MethodKind.Constructor && !method.IsStatic)
            .ToArray();

        if (constructors.Length == 0)
        {
            return true;
        }

        IMethodSymbol? @default = Array.Find(constructors, constructor => constructor.Parameters.IsEmpty);

        return @default is not null && @default.DeclaredAccessibility.HasFlag(Accessibility.Internal);
    }

    private static bool HasExtension(ITypeSymbol feature)
    {
        return feature.ContainingNamespace
            .GetMembers()
            .OfType<INamedTypeSymbol>()
            .Any(type => type.IsStatic && type.Name.Equals($"{feature.Name}Extensions"));
    }

    private static bool IsFeature(INamedTypeSymbol @interface)
    {
        return @interface.IsGenericType && @interface.TypeArguments.Length == 1 && @interface.Name == TypeName;
    }

    private static bool IsMatch(SyntaxNode syntax, CancellationToken cancellationToken)
    {
        if (syntax is TypeDeclarationSyntax type
         && type.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword))
         && type.BaseList is not null)
        {
            return type.BaseList.Types
                .Select(@base => @base.Type)
                .OfType<SimpleNameSyntax>()
                .Any(name => name.Identifier.ValueText == TypeName);
        }

        return false;
    }

    private static IEnumerable<Feature> Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        if (context.Node is TypeDeclarationSyntax type)
        {
            INamedTypeSymbol? symbol = context.SemanticModel.GetDeclaredSymbol(type);

            if (symbol is not null)
            {
                IEnumerable<INamedTypeSymbol> features = symbol.Interfaces.Where(IsFeature);

                Lazy<IPropertySymbol[]> properties = new(() => symbol
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Where(property => !property.IsStatic)
                    .ToArray());

                bool IsDefinedInType(INamedTypeSymbol @interface)
                {
                    return !Array.Exists(properties.Value, property => property.Type.Equals(@interface.TypeArguments[0], SymbolEqualityComparer.Default));
                }

                foreach (INamedTypeSymbol feature in features)
                {
                    string name = feature.TypeArguments[0].Name;
                    string @namespace = feature.TypeArguments[0].ContainingNamespace.ToDisplayString();
                    string key = $"{@namespace}.{name}";

                    if (!cache.TryGetValue(key, out Attribute attribute))
                    {
                        attribute = new Attribute
                        {
                            HasDefaultConstructor = HasDefaultConstructor(feature.TypeArguments[0]),
                            HasExtension = HasExtension(feature.TypeArguments[0]),
                            Name = name,
                            Namespace = @namespace,
                        };

                        cache.Add(key, attribute);
                    }

                    yield return new Feature
                    {
                        Attribute = attribute,
                        HasProperty = IsDefinedInType(feature),
                        Name = symbol.Name,
                        Namespace = symbol.ContainingNamespace.ToDisplayString(),
                        Type = type.Keyword.ValueText,
                    };
                }
            }
        }
    }
}