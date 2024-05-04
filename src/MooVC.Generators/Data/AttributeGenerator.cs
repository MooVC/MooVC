namespace MooVC.Generators.Data;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MooVC.Generators.Semantics;
using MooVC.Generators.Syntax;

/// <summary>
/// Supports extension generation relating to the use of the MooVC.Data.IFeature and MooVC.Data.IFeatures.
/// </summary>
public abstract partial class AttributeGenerator
    : IIncrementalGenerator
{
    private static readonly Dictionary<string, Attribute> cache = [];
    private readonly string prefix;
    private readonly string typeName;

    /// <summary>
    /// Facilitates creation of an instance of a generator which expands upon the functionality associated with the identified attribute.
    /// </summary>
    /// <param name="prefix">The prefix to be placed ahead of the attribute name on the extension method.</param>
    /// <param name="typeName">The interface type to be matched on a given subject, enlisting it as a candidate for source generation.</param>
    private protected AttributeGenerator(string prefix, string typeName)
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

    /// <summary>
    /// Generates the source code needed to support an extension that allows for an instance of the attribute to be specified.
    /// </summary>
    /// <param name="attribute">The definition of the <see cref="Attribute"/> for which the extension is to be generated.</param>
    /// <returns>The source code for the extension method.</returns>
    protected abstract string GenerateInstanceExtension(Attribute attribute);

    /// <summary>
    /// Generates the source code needed to support an extension that allows for a delegate that configures the attribute to be specified.
    /// </summary>
    /// <param name="attribute">The definition of the <see cref="Attribute"/> for which the extension is to be generated.</param>
    /// <returns>The source code for the extension method.</returns>
    protected abstract string GenerateMutatorExtension(Attribute attribute);

    /// <summary>
    /// Generates an explicit property within the class that implements the interface.
    /// </summary>
    /// <param name="subject">The definition of the type that forms the <see cref="Subject" /> of the implementation.</param>
    /// <returns>The source code for the explictly property that implements the identified interface.</returns>
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
        return @interface.IsOfType(typeName, arguments: 1);
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