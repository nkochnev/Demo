namespace Demo.DependencyInjection.Service.Interfaces
{
    public interface ISender
    {
        void SendEmail(string subject, string body, string email);
    }
}
