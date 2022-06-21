namespace MooVC;

using System;
using System.Reflection;
using static System.String;
using static MooVC.Resources;

public static partial class MulticastDelegateExtensions
{
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