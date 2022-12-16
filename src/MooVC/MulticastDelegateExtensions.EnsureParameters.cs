namespace MooVC;

using System;
using System.Reflection;
using static System.String;
using static MooVC.Resources;

/// <summary>
/// Provides methods to support event propagation.
/// </summary>
public static partial class MulticastDelegateExtensions
{
    /// <summary>
    /// Ensures that a multicast delegate matches the expected signature for a derivation of the AsyncEventHandler.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender from which the event has originated.</typeparam>
    /// <typeparam name="TArgs">The type of the event arguments.</typeparam>
    /// <param name="method">The method definition for the multicast delegate.</param>
    /// <exception cref="NotSupportedException">
    /// The multicast delegate does not match the expected signature for an AsyncEventHandler.
    /// </exception>
    private static void EnsureParameters<TSender, TArgs>(MethodInfo method)
        where TSender : class
        where TArgs : EventArgs
    {
        ParameterInfo[] parameters = method.GetParameters();

        if (parameters.Length != 2)
        {
            throw new NotSupportedException(MulticastDelegateExtensionsEnsureParametersIncorrectNumberOfParameters);
        }

        Type senderType = typeof(TSender);

        if (!parameters[0].ParameterType.IsAssignableFrom(senderType))
        {
            throw new NotSupportedException(Format(
                MulticastDelegateExtensionsEnsureParametersIncorrectSenderParameterType,
                senderType.FullName));
        }

        Type argsType = typeof(TArgs);

        if (!parameters[1].ParameterType.IsAssignableFrom(argsType))
        {
            throw new NotSupportedException(Format(
                MulticastDelegateExtensionsEnsureParametersIncorrectArgsParameterType,
                argsType.FullName));
        }
    }
}