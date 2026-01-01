namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a C# member syntax method.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
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
        /// Gets or sets the body on the Method.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the extensibility on the Method.
        /// </summary>
        /// <value>The extensibility.</value>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets a value indicating whether the Method is undefined.
        /// </summary>
        /// <value>A value indicating whether the Method is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Method.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        /// <summary>
        /// Gets or sets the parameters on the Method.
        /// </summary>
        /// <value>The parameters.</value>
        [Descriptor("Accepts")]
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets or sets the result on the Method.
        /// </summary>
        /// <value>The result.</value>
        [Descriptor("Returns")]
        public Result Result { get; internal set; } = Result.Task;

        /// <summary>
        /// Gets or sets the scope on the Method.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Method method)
        {
            Guard.Against.Conversion<Method, string>(method);

            return method.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Method method)
        {
            Guard.Against.Conversion<Method, Snippet>(method);

            return Snippet.From(method);
        }

        /// <summary>
        /// Returns the string representation of the Method.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Method)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature(options);

            if (Body.IsEmpty)
            {
                return signature.Append(';');
            }

            return Body.Block(options, signature);
        }

        /// <summary>
        /// Validates the Method.
        /// </summary>
        /// <remarks>Required members include: Extensibility, Parameters, Name, Result.</remarks>
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
                Extensibility.Abstract,
                Extensibility.Implicit,
                Extensibility.Override,
                Extensibility.Sealed + Extensibility.Override,
                Extensibility.Virtual))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, nameof(Event)),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, results, Parameters)
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .And(nameof(Result), Result)
                .Results;
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string result = Result.IsVoid ? "void" : Result;
            string scope = Scope;
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
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