namespace MooVC
{
    using System;

    public static partial class Ensure
    {
        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNull(object argument, string argumentName, string message)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}