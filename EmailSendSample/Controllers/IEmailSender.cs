namespace EmailSendSample.Controllers
{
    public interface IEmailSender
    {
        void SendEmail(string toEmail, string subject);
    }
}
