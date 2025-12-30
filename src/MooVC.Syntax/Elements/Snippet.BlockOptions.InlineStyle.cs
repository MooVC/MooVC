namespace MooVC.Syntax.Elements
{
    using Monify;

    public partial class Snippet
    {
        public partial class BlockOptions
        {
            [Monify(Type = typeof(int))]
            public partial class InlineStyle
            {
                public static readonly InlineStyle Lambda = 0;
                public static readonly InlineStyle SingleLineBraces = 1;
                public static readonly InlineStyle MultiLineBraces = 2;

                private InlineStyle(int value)
                {
                    _value = value;
                }

                public bool IsLambda => this == Lambda;

                public bool IsSingleLineBraces => this == SingleLineBraces;

                public bool IsMultiLineBraces => this == MultiLineBraces;
            }
        }
    }
}