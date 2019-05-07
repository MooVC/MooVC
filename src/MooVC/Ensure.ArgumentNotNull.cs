namespace MooVC
{
    using System;

    public static partial class Ensure
    {
        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNull(object argument, string argumentName, string message)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}