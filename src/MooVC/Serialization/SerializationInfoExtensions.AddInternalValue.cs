namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static void AddInternalValue(this SerializationInfo info, string name, short value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, char value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, byte value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, bool value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, decimal value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, ulong value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, double value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, uint value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, float value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, sbyte value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, object value, Type type)
        {
            info.AddValue(FormatName(name), value, type);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, object value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, long value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, int value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, ushort value)
        {
            info.AddValue(FormatName(name), value);
        }

        public static void AddInternalValue(this SerializationInfo info, string name, DateTime value)
        {
            info.AddValue(FormatName(name), value);
        }

        private static string FormatName(string name)
        {
            return $"_{name.ToLower()}";
        }
    }
}