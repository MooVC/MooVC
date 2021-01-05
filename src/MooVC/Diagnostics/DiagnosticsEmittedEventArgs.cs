namespace MooVC.Diagnostics
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.Serialization;
    using MooVC.Serialization;
    using static System.String;

    [Serializable]
    public sealed class DiagnosticsEmittedEventArgs
        : EventArgs,
          ISerializable
    {
        private readonly Exception? cause;
        private readonly Level level = Level.Information;
        private readonly string message = string.Empty;

        public DiagnosticsEmittedEventArgs()
        {
        }

        private DiagnosticsEmittedEventArgs(SerializationInfo info, StreamingContext context)
        {
            cause = info.TryGetValue<Exception?>(nameof(Cause));
            level = info.GetValue<Level>(nameof(Level));
            message = info.GetValue<string>(nameof(Message));
        }

        public Exception? Cause
        {
            get => cause;
            init
            {
                if (value is { } && IsNullOrWhiteSpace(Message))
                {
                    Message = value.Message;
                }

                cause = value;
            }
        }

        public Level Level
        {
            get => level;
            init
            {
                if (Enum.IsDefined(typeof(Level), value))
                {
                    level = value;
                }
                else
                {
                    level = Enum.GetValues<Level>().Max();
                }
            }
        }

        [AllowNull]
        public string Message
        {
            get => message;
            init
            {
                if (IsNullOrWhiteSpace(value))
                {
                    message = Cause?.Message ?? string.Empty;
                }
                else
                {
                    message = value;
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _ = info.TryAddValue(nameof(Cause), Cause);
            info.AddValue(nameof(Level), Level);
            info.AddValue(nameof(Message), Message);
        }
    }
}