namespace MooVC.Logging
{
    using System;
    using static System.String;
    using static MooVC.Ensure;
    using static Resources;

    public class ExceptionEventArgs
        : EventArgs
    {
        public ExceptionEventArgs(string message, Exception? exception = null)
        {
            ArgumentIsAcceptable(
                message,
                nameof(message),
                value => !IsNullOrWhiteSpace(value),
                ExceptionEventArgsMessageRequired);

            Message = message;
            Exception = exception;
        }

        public ExceptionEventArgs(Exception exception)
        {
            ArgumentNotNull(exception, nameof(exception), ExceptionEventArgsExceptionRequired);

            Message = exception.Message;
            Exception = exception;
        }

        public Exception? Exception { get; }

        public string Message { get; }
    }
}