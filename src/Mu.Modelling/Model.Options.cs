namespace Mu.Modelling;

using SyntaxOptions = MooVC.Syntax.CSharp.Concepts.Options;

public sealed partial class Model
{
    public sealed record Options(GithubOptions Github, SyntaxOptions Syntax)
    {
        public static readonly Options Default = new();

        public Options()
            : this(GithubOptions.Default, SyntaxOptions.Default)
        {
        }

        public static implicit operator SyntaxOptions(Options options)
        {
            ArgumentNullException.ThrowIfNull(options);
            return options.Syntax;
        }

        public sealed record GithubOptions(string ApiBaseAddress, string Owner, string Repository, string Reference, string Token)
        {
            private const string DefaultApiBaseAddress = "https://api.github.com/";

            public static readonly GithubOptions Default = new(DefaultApiBaseAddress, string.Empty, string.Empty, "HEAD", string.Empty);

            public bool IsConfigured => !string.IsNullOrWhiteSpace(Owner) && !string.IsNullOrWhiteSpace(Repository);

            public string ContentsPath(string path)
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    return $"repos/{Owner}/{Repository}/contents?ref={Reference}";
                }

                return $"repos/{Owner}/{Repository}/contents/{path}?ref={Reference}";
            }
        }
    }
}