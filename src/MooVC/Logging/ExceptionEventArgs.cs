namespace MooVC.Logging
{
    using System;

    public class ExceptionEventArgs 
        : EventArgs
    {
        public ExceptionEventArgs(string message, Exception exception = null)
        {
            Ensure.ArgumentIsAcceptable(
                message,
                nameof(message),
                value => !string.IsNullOrWhiteSpace(value),
                Resources.ExceptionEventArgsMessageRequired);

            Message = message;
            Exception = exception;
        }

        public ExceptionEventArgs(Exception exception)
        {
            Ensure.ArgumentNotNull(exception, nameof(exception));

            Message = exception.Message;
            Exception = exception;
        }

        public Exception Exception { get; }

        public string Message { get; }
    }
}