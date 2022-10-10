using System.Diagnostics;
using MailKit.Security;

namespace MailKitExampleV6.MailLogic
{
    public class MailSendLogic : IMailSendLogic
    {
        private string SmtpHost = "smtp.office365.com";
        private int SmtpPort = 587;
        private string User = "who@???.onmicrosoft.com";
        private string Pass = "password";
        public async Task SendMailAsync(string? to, string? from, string? subject, string? text)
        {
            var message = new MimeKit.MimeMessage();
            // 宛先情報  
            message.From.Add(new MimeKit.MailboxAddress("<宛名>", from));
            // 送り元情報  
            message.To.Add(new MimeKit.MailboxAddress("<送信者名>", to));
            // 表題  
            message.Subject = subject;
            // 内容  
            var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
            textPart.Text = text;
            message.Body = textPart;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    // SMTPサーバに接続  
                    await client.ConnectAsync(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
                    Debug.WriteLine("接続完了");

                    // SMTPサーバ認証（あれば）  
                    await client.AuthenticateAsync(User, Pass);

                    // 送信  
                    await client.SendAsync(message);

                    // 切断  
                    await client.DisconnectAsync(true);

                }
                catch (Exception e)
                {
                    Debug.WriteLine("{0} Exception caught.", e);
                }
            }
        }
    }
}
