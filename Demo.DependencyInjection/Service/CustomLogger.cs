using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Demo.DependencyInjection.Service.Interfaces;

namespace Demo.DependencyInjection.Service
{
    public class CustomLogger : ILogger
    {
        const string Path = @"c:\temp\customdemologs.txt";

        public void Error(Exception exception)
        {
            File.AppendAllText(Path, exception.ToString());
            File.AppendAllText(Path, Environment.NewLine);
        }

        public void Info(string message)
        {
            File.AppendAllText(Path, message);
            File.AppendAllText(Path, Environment.NewLine);
        }
    }
}