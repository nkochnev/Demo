using System;

namespace Demo.DependencyInjection.Service.Interfaces
{
    public interface ILogger
    {
        void Error(Exception exception);

        void Info(string message);
    }
}
