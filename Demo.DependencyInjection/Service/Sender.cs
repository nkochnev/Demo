using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.DependencyInjection.Service.Interfaces;

namespace Demo.DependencyInjection.Service
{
    public class Sender : ISender
    {
        private readonly ILogger _logger;

        public Sender(ILogger logger)
        {
            _logger = logger;
        }

        public void SendEmail(string subject, string body, string email)
        {
            _logger.Info(string.Format("Тема: {0}. Кому: {1}. Содержание письма: {2}", subject, email, body));
        }
    }
}