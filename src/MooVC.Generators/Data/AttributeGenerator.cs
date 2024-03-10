namespace MooVC.Generators.Data;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MooVC.Generators.Semantics;
using MooVC.Generators.Syntax;

/// <summary>
/// Generates implementation elements for IFeature within an class or record that declares that it is an implementation.
/// Also generates an extension that supports consumption of the Feature through the prefix "With".
/// </summary>
public abstract partial class AttributeGenerator
    : IIncrementalGenerator
{
    private static readonly Dictionary<string, Attribute> cache = [];
    private readonly string prefix;
    private readonly string typeName;

    protected AttributeGenerator(string prefix, string typeName)
    {
        this.prefix = prefix;
        this.typeName = typeName;
    }

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<IEnumerable<Subject>> declarations = context
            .SyntaxProvider
            .CreateSyntaxProvider(IsMatch, Transform)
            .Collect()
            .Select(static (collections, _) => collections.SelectMany(models => models));

        context.RegisterImplementationSourceOutput(declarations, Generate);
    }

    protected abstract string GenerateInstanceExtension(Attribute attribute);

    protected abstract string GenerateMutatorExtension(Attribute attribute);

    protected abstract string GenerateProperty(Subject subject);

    private static void GenerateExtension(Attribute attribute, SourceProductionContext context, string name, Func<Attribute, string> method, string prefix)
    {
        string content = $$"""
            namespace {{attribute.Namespace}};

            using MooVC;
            using MooVC.Data;
            
            public static partial class {{attribute.Name}}Extensions
            {
            {{method(attribute)}}
            }
            """;

        context.AddSource($"{attribute.Namespace}.{attribute.Name}Extensions.{prefix}{attribute.Name}.{name}.g.cs", content);
    }

    private void Generate(SourceProductionContext context, IEnumerable<Subject> subjects)
    {
        foreach (IGrouping<Attribute, Subject> attribute in subjects.GroupBy(feature => feature.Attribute))
        {
            foreach (Subject subject in attribute.Where(feature => feature.HasProperty))
            {
                string content = GenerateProperty(subject);

                context.AddSource($"{subject.Namespace}.{subject.Name}.{subject.Attribute.Name}.g.cs", content);
            }

            if (!attribute.Key.HasExtension)
            {
                if (attribute.Key.HasDefaultConstructor)
                {
                    GenerateExtension(attribute.Key, context, "Mutator", GenerateMutatorExtension, prefix);
                }

                GenerateExtension(attribute.Key, context, "Instance", GenerateInstanceExtension, prefix);
            }
        }
    }

    private bool IsOfType(INamedTypeSymbol @interface)
    {
        return @interface.DerivesFrom(typeName, arguments: 1);
    }

    private bool IsMatch(SyntaxNode syntax, CancellationToken cancellationToken)
    {
        return syntax is TypeDeclarationSyntax type && type.IsPartial() && type.DerivesFrom(typeName);
    }

    private IEnumerable<Subject> Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        if (context.Node is TypeDeclarationSyntax type)
        {
            INamedTypeSymbol? symbol = context.SemanticModel.GetDeclaredSymbol(type);

            if (symbol is not null)
            {
                IEnumerable<INamedTypeSymbol> features = symbol.Interfaces.Where(IsOfType);

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
                            HasDefaultConstructor = feature.TypeArguments[0].HasDefaultConstructor(),
                            HasExtension = feature.TypeArguments[0].HasExtensions(),
                            Name = name,
                            Namespace = @namespace,
                        };

                        cache.Add(key, attribute);
                    }

                    yield return new Subject
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