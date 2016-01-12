using System;

namespace ElectricHead.GameVc.ErrorHandling
{
    public class ErrorActionHandler : IGlobalErrorHandler
    {
        private readonly Action<Exception> _action;

        public ErrorActionHandler(Action<Exception> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
        }

        public void OnException(Exception exception)
        {
            _action(exception);
        }
    }
}