//using Microsoft.AspNetCore.Mvc;
//using MailKit.Net.Smtp;
//using MimeKit;
//using System.Net.Mail;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Project.Controllers
//{
    

//    public class EmailService
//    {
//        public async Task SendEmailAsync(string to, string subject, string body)
//        {
//            var message = new MimeMessage();
//            message.From.Add(new MailboxAddress("Your Name", "your_email@example.com"));
//            message.To.Add(new MailboxAddress("", to));
//            message.Subject = subject;
//            message.Body = new TextPart("plain")
//            {
//                Text = body
//            };

//            using (var client = new SmtpClient())
//            {
//                await client.ConnectAsync("smtp.example.com", 587, false);
//                await client.AuthenticateAsync("your_email@example.com", "your_password");
//                await client.SendAsync(message);
//                await client.DisconnectAsync(true);
//            }
//        }
//    }

//}
