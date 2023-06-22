﻿namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Serialization;
using static MooVC.Serialization.Resources;

public static partial class SerializationInfoExtensions
{
    private const string MethodName = "GetValueNoThrow";
    private static readonly Lazy<MethodInfo> method;

    static SerializationInfoExtensions()
    {
        method = new Lazy<MethodInfo>(CreateMethodInfo);
    }

    private static MethodInfo Method => method.Value;

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
#if NET6_0_OR_GREATER
    [return: NotNullIfNotNull(nameof(defaultValue))]
#endif
    public static T? TryGetValue<T>(this SerializationInfo info, string name, T? defaultValue = default)
    {
        try
        {
            object? value = Method.Invoke(info, new object[] { name, typeof(T) });

            if (value is T result)
            {
                return result;
            }

            return defaultValue;
        }
        catch
        {
            return defaultValue;
        }
    }

    private static MethodInfo CreateMethodInfo()
    {
        Type type = typeof(SerializationInfo);

        MethodInfo? method = type.GetMethod(
            MethodName,
            BindingFlags.Instance | BindingFlags.NonPublic);

        if (method is null)
        {
            throw new InvalidOperationException(SerializationInfoExtensionsCreateMethodInfoFailure);
        }

        return method;
    }
}