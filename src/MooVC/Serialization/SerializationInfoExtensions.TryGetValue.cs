namespace MooVC.Serialization
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        private const string MethodName = "GetValueNoThrow";
        private static readonly Lazy<MethodInfo> method;

        static SerializationInfoExtensions()
        {
            method = new Lazy<MethodInfo>(CreateMethodInfo);
        }

        private static MethodInfo Method => method.Value;

        [return: NotNullIfNotNull("defaultValue")]
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

            return type.GetMethod(
                MethodName,
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}