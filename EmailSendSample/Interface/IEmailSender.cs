namespace EmailSendSample.Interface
{
    public interface IEmailSender
    {
        void SendEmail(string toEmail, string subject);
    }
}
