namespace EmailSendSample.Model
{
    public class EmailModel
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; } // You can add a property for the email body if needed
    }
}
