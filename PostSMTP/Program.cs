using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PostSMTP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new SmtpClient("smtp.mail.ru", 465);
            client.Credentials = new NetworkCredential("amigo_south@mail.ru", "123456789");
            client.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("amigo_south@mail.ru", "владыка");
            message.To.Add(new MailAddress("another_mail@mail.ru", "вася"));
            message.Subject = "Я УВЕЛИЧИЛ НА 5 МЕТРОВ";
            message.Attachments.Add(new Attachment("1.txt"));
            message.Body = "Я УВЕЛИЧИЛ НА 5 МЕТРОВ ПРЫЖКИ В ДЛИНУ С КЛУБОМ ФИТНЕС ПРО.";
            await client.SendMailAsync(message);
        }
    }
}
