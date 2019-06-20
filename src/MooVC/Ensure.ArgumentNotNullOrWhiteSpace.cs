namespace MooVC
{
    using System;

    public static partial class Ensure
    {
        public static void ArgumentNotNullOrWhiteSpace(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNullOrWhiteSpace(string argument, string argumentName, string message)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}