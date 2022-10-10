namespace MailKitExampleV6.Models
{
    public class SendMailModel
    {
        // string to, string from, string subject, string text
        public string? SendTo { get; set; }
        public string? SendFrom { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }

    }
}
