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
    /// Represents a C# method declaration, including signature and body.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IValidatableObject
    {
        /// <summary>
        /// Gets an undefined method declaration.
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
        /// Gets or sets the method body snippet.
        /// </summary>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the extensibility modifier (abstract, virtual, override, etc.).
        /// </summary>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets a value indicating whether the method declaration is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the method name declaration.
        /// </summary>
        [Descriptor("Named")]
        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        /// <summary>
        /// Gets or sets the parameter list for the method signature.
        /// </summary>
        [Descriptor("Accepts")]
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets or sets the return signature, including async modality and return type.
        /// </summary>
        [Descriptor("Returns")]
        public Result Result { get; internal set; } = Result.Task;

        /// <summary>
        /// Gets or sets the accessibility scope for the method.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Method.
        /// </summary>
        public static implicit operator string(Method method)
        {
            Guard.Against.Conversion<Method, string>(method);

            return method.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Method.
        /// </summary>
        public static implicit operator Snippet(Method method)
        {
            Guard.Against.Conversion<Method, Snippet>(method);

            return Snippet.From(method);
        }

        /// <summary>
        /// Returns the string representation of the Method.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
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
        /// Validates the Method and returns validation results.
        /// </summary>
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
