namespace MooVC.Logging
{
    using System;
    using static System.String;
    using static MooVC.Ensure;
    using static Resources;

    public sealed class PassiveExceptionEventArgs
        : EventArgs
    {
        public PassiveExceptionEventArgs(string message, Exception? exception = default)
        {
            ArgumentIsAcceptable(
                message,
                nameof(message),
                value => !IsNullOrWhiteSpace(value),
                ExceptionEventArgsMessageRequired);

            Message = message;
            Exception = exception;
        }

        public PassiveExceptionEventArgs(Exception exception)
        {
            ArgumentNotNull(exception, nameof(exception), ExceptionEventArgsExceptionRequired);

            Message = exception.Message;
            Exception = exception;
        }

        public Exception? Exception { get; }

        public string Message { get; }
    }
}