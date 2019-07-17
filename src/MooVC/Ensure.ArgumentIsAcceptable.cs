namespace MooVC
{
    using System;

    public static partial class Ensure
    {
        public static void ArgumentIsAcceptable<T>(
            T argument, 
            string argumentName, 
            Func<T, bool> predicate, 
            string message)
        {
            ArgumentNotNull(argument, argumentName, message);

            if (!predicate(argument))
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}