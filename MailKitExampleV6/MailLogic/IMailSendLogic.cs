namespace MailKitExampleV6.MailLogic
{
    public interface IMailSendLogic
    {
        Task SendMailAsync(string? to, string? from, string? subject, string? text);
    }
}