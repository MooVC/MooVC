namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Monify;

    public partial class Qualifier
    {
        [Monify(Type = typeof(int))]
        [SkipAutoInstantiation]
        public sealed partial class Options
        {
            public static readonly Options Block = 1;
            public static readonly Options File = 0;

            private Options(int value)
            {
                _value = value;
            }

            public bool IsBlock => this == Block;

            public bool IsFile => this == File;

            public override string ToString()
            {
                if (IsBlock)
                {
                    return nameof(Block);
                }

                return nameof(File);
            }
        }
    }
}