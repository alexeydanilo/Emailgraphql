using MimeKit;


namespace Emailgraphql.SendingLetter
{
    public class SendEmail
    {
        public string Email(string email, string topic, string fromwho, string letter)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromwho, "oleksii.danylo@nure.ua"));
                message.To.Add(new MailboxAddress("Alexey", email));
                message.Subject = topic;
                message.Body = new BodyBuilder() { HtmlBody = letter }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("oleksii.danylo@nure.ua", "D0N41K776");
                    client.Send(message);

                    client.Disconnect(true);
                   
                    return "Сообщение отправлено успешно";
                }


            }
            catch 
            {
                
                return "ошибка";
            }

        }
    }
}
