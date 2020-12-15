namespace MooVC.Diagnostics
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using static System.String;

    public sealed class DiagnosticsEmittedEventArgs
        : EventArgs
    {
        private readonly Exception? cause;
        private readonly Level level = Level.Information;
        private readonly string message = string.Empty;

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
    }
}