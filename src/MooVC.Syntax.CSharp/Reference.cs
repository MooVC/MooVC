namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Reference_Resources;

    /// <summary>
    /// Represents a referenced namespace or type used by a definition.
    /// </summary>
    public abstract partial class Reference
        : Type
    {
        private const string Separator = " ";
        private readonly Variable.Options _options;
        private readonly string _type;

        private protected Reference(Variable.Options options, string type)
        {
            _options = options;
            _type = type;
        }

        /// <summary>
        /// Gets the symbol from which the Reference derives.
        /// </summary>
        /// <value>The base type.</value>
        [Descriptor("DerivesFrom")]
        [SuppressMessage("Usage", "FLTFY03:Type does not utilize Fluentify", Justification = "The derived class will be annotated with it.")]
        public Base Base { get; internal set; } = Base.Unspecified;

        /// <summary>
        /// Gets the constructors on the Reference.
        /// </summary>
        /// <value>The constructors.</value>
        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        /// <summary>
        /// Gets the extensibility on the Reference.
        /// </summary>
        /// <value>The extensibility.</value>
        public Modifiers Extensibility { get; internal set; } = Modifiers.Sealed;

        /// <summary>
        /// Gets the fields on the Reference.
        /// </summary>
        /// <value>The fields.</value>
        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        /// <summary>
        /// Gets the parameters on the Reference.
        /// </summary>
        /// <value>The parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Returns an enumerator that iterates through the collection of symbols.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public override IEnumerator<Qualifier> GetEnumerator()
        {
            IEnumerator<Qualifier> @base = base.GetEnumerator();

            while (@base.MoveNext())
            {
                yield return @base.Current;
            }

            foreach (Qualifier qualifier in Base
                .Concat(Constructors.SelectMany(constructor => constructor))
                .Concat(Fields.SelectMany(field => field))
                .Concat(Parameters.SelectMany(parameter => parameter)))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Validates the Reference.
        /// </summary>
        /// <remarks>Required members include: Extensibility, Constructors, Fields, Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            if (!Extensibility.IsPermitted(Modifiers.Abstract, Modifiers.Implicit, Modifiers.Sealed))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, GetType()),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Base.IsUnspecified, nameof(Base), results, Base)
                .AndIf(!Constructors.IsDefaultOrEmpty, nameof(Constructors), Constructors)
                .AndIf(!Fields.IsDefaultOrEmpty, nameof(Fields), Fields)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), Parameters)
                .Results;
        }

        /// <summary>
        /// Performs the get signature operation for the C# type syntax.
        /// </summary>
        /// <param name="extensibility">The extensibility.</param>
        /// <param name="partial">The partial.</param>
        /// <param name="name">The name.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>The string.</returns>
        protected virtual string GetSignature(string extensibility, string partial, string name, string scope)
        {
            return Separator.Combine(scope, extensibility, partial, _type, $"{name}");
        }

        /// <summary>
        /// Merges the specified attribute, body, and signature snippets into a single snippet using the provided
        /// options.
        /// </summary>
        /// <param name="attributes">The snippet containing attribute information to be prepended to the merged result.</param>
        /// <param name="body">The main body snippet to be merged.</param>
        /// <param name="options">The options that control how the snippets are merged.</param>
        /// <param name="signature">The snippet representing the signature to be included in the merged result.</param>
        /// <returns>A new snippet that combines the attributes, body, and signature according to the specified options.</returns>
        protected virtual Snippet Merge(Snippet attributes, Snippet body, Options options, Snippet signature)
        {
            return body
                .Block(options, signature)
                .Prepend(options, attributes);
        }

        /// <summary>
        /// Performs the perform to snippet operation for the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The snippet.</returns>
        protected override Snippet PerformToSnippet(Options options)
        {
            Snippet signature = GetSignature(options);

            var attributes = Attributes.ToSnippet(options);
            var constructors = Constructors.ToSnippet(options, this);
            var events = Events.ToSnippet(options);
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var operators = Operators.ToSnippet(options, this);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            var elements = new Snippet[] { fields, constructors, events, properties, indexers, operators, methods };
            IEnumerable<Snippet> types = Types.Select(type => type.ToSnippet(options));
            Snippet body = Snippet.Blank.Combine(options, elements.Concat(types).ToArray());

            return Merge(attributes, body, options, signature);
        }

        private Snippet GetSignature(Options options)
        {
            var clauses = Declaration.Arguments.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string extensibility = Extensibility;
            string name = Declaration;
            Snippet parameters = GetParameters(options);
            string partial = IsPartial.Partial();
            string scope = Scope;
            string signature = GetSignature(extensibility, partial, name, scope);

            if (!parameters.IsEmpty)
            {
                signature = $"{signature}({parameters})";
            }

            var declaration = Snippet.From(options, signature);

            if (!Base.IsUnspecified)
            {
                var @base = Base.ToSnippet(options);

                @base = Snippet.From(options, $": {@base}");

                declaration = @base
                    .Shift(options)
                    .Prepend(options, signature);
            }

            if (!clauses.IsEmpty)
            {
                return clauses
                    .Shift(options)
                    .Prepend(options, declaration);
            }

            return declaration;
        }

        private Snippet GetParameters(Options options)
        {
            return Parameters.ToSnippet(Parameter.Options.Pascal
                .WithAttributes(options)
                .WithNaming(_options)
                .WithQualifications(options)
                .WithSnippets(options));
        }
    }
}