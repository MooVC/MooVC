namespace MooVC
{
    using System;
    using static System.String;

    public static partial class Ensure
    {
        public static void ArgumentNotNullOrWhiteSpace(string argument, string argumentName)
        {
            if (IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNullOrWhiteSpace(string argument, string argumentName, string message)
        {
            if (IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}