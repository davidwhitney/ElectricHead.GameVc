using System;

namespace ElectricHead.GameVc.ErrorHandling
{
    public interface IGlobalErrorHandler
    {
        void OnException(Exception exception);
    }
}