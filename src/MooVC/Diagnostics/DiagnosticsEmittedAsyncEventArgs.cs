namespace MooVC.Diagnostics
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using System.Threading;
    using MooVC.Serialization;
    using static System.String;

    [Serializable]
    public sealed class DiagnosticsEmittedAsyncEventArgs
        : AsyncEventArgs,
          ISerializable
    {
        private Exception? cause;
        private Level level = Level.Information;
        private string message = string.Empty;

        public DiagnosticsEmittedAsyncEventArgs(
            CancellationToken? cancellationToken = default,
            Exception? cause = default,
            Level level = Level.Information,
            string? message = default)
            : base(cancellationToken: cancellationToken)
        {
            Cause = cause;
            Level = level;
            Message = message;
        }

        private DiagnosticsEmittedAsyncEventArgs(SerializationInfo info, StreamingContext context)
            : base(default)
        {
            cause = info.TryGetValue<Exception?>(nameof(Cause));
            level = info.GetValue<Level>(nameof(Level));
            message = info.GetValue<string>(nameof(Message));
        }

        public Exception? Cause
        {
            get => cause;
            private set
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
            private set
            {
                if (Enum.IsDefined(typeof(Level), value))
                {
                    level = value;
                }
                else
                {
                    level = Level.Critical;
                }
            }
        }

        [AllowNull]
        public string Message
        {
            get => message;
            private set
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