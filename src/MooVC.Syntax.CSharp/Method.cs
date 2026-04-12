namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# method declaration, including its signature, modifiers, and body.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined method declaration, used as a placeholder in builders.
        /// </summary>
        public static readonly Method Undefined = new Method();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Method class.
        /// </summary>
        internal Method()
        {
        }

        /// <summary>
        /// Gets the attributes associated with the Property.
        /// </summary>
        /// <value>The attributes.</value>
        [Descriptor("AttributedWith")]
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the body snippet emitted after the method signature.
        /// </summary>
        /// <value>The statement or block content for the method body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the extensibility modifier applied to the method declaration.
        /// </summary>
        /// <value>The extensibility modifier (abstract, virtual, override, etc.).</value>
        public Modifiers Extensibility { get; internal set; } = Modifiers.Implicit;

        /// <summary>
        /// Gets a value indicating whether this method declaration is the undefined sentinel.
        /// </summary>
        /// <value>A value indicating whether this instance is the undefined sentinel.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the method name declaration.
        /// </summary>
        /// <value>The declared method identifier.</value>
        [Descriptor("Named")]
        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        /// <summary>
        /// Gets the parameter list used to form the method signature.
        /// </summary>
        /// <value>The ordered parameters accepted by the method.</value>
        [Descriptor("Accepts")]
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets the return signature, including async modality and return type.
        /// </summary>
        /// <value>The return signature that will be emitted in the method declaration.</value>
        [Descriptor("Returns")]
        public Result Result { get; internal set; } = Result.Task;

        /// <summary>
        /// Gets the accessibility scope applied to the method declaration.
        /// </summary>
        /// <value>The accessibility modifier (public, internal, etc.).</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Converts the method declaration to its C# source representation.
        /// </summary>
        /// <param name="method">The method declaration to render.</param>
        /// <returns>The rendered C# source text.</returns>
        public static implicit operator string(Method method)
        {
            Guard.Against.Conversion<Method, string>(method);

            return method.ToString();
        }

        /// <summary>
        /// Converts the method declaration to a snippet for composition.
        /// </summary>
        /// <param name="method">The method declaration to convert.</param>
        /// <returns>The snippet representing the method declaration.</returns>
        public static implicit operator Snippet(Method method)
        {
            Guard.Against.Conversion<Method, Snippet>(method);

            return Snippet.From(method);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the sequence of symbols representing the name, parameters, and result.
        /// </summary>
        /// <remarks>
        /// The enumerator yields symbols in the order they appear in the name, followed by all parameter symbols, and then
        /// the result symbols. The returned enumerator supports only forward iteration.
        /// </remarks>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection of symbols in order: name, parameters, and result.
        /// </returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Name
                .Concat(Parameters.SelectMany(parameter => parameter))
                .Concat(Result))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the C# source representation of the method declaration.
        /// </summary>
        /// <returns>The rendered method declaration.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Snippet), nameof(Method)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            var attributes = Attributes.ToSnippet(options);
            Snippet signature = GetSignature(options);

            if (Body.IsEmpty)
            {
                return signature.Append(';');
            }

            return Body
                .Block(options, signature)
                .Prepend(options, attributes);
        }

        /// <summary>
        /// Validates the method declaration for a renderable signature.
        /// </summary>
        /// <remarks>
        /// Ensures the extensibility modifier is permitted, the name is specified, the return signature is valid,
        /// and any provided parameters are defined.
        /// </remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (!Extensibility.IsPermitted(
                Modifiers.Abstract,
                Modifiers.Implicit,
                Modifiers.Override,
                Modifiers.Sealed + Modifiers.Override,
                Modifiers.Virtual))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, nameof(Event)),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUnspecified, results, Attributes)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .And(nameof(Result), Result)
                .Results;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Snippet GetSignature(Options options)
        {
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(options);
            string result = Result.IsVoid ? "void" : Result;
            string scope = Scope.ToString(options);
            var clauses = Name.Arguments.ToSnippet(parameter => parameter.ToConstraintsSnippet(options), options);
            string signature = Separator.Combine(scope, extensibility, result, $"{name}({parameters})");

            if (!clauses.IsEmpty)
            {
                return clauses
                    .Shift(options)
                    .Prepend(options, Environment.NewLine)
                    .Prepend(options, signature);
            }

            return Snippet.From(options, signature);
        }
    }
}