namespace NarouBackend.util;

using System.Net;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


public class EmailSender : IEmailSender {

    public async Task SendEmailAsync(string toEmail, string subject, string message) {
        await Execute(subject, message, toEmail);
    }

    public async Task Execute(string subject, string message, string toEmail) {
        var msg = new MimeMessage();
        msg.From.Add(new MailboxAddress("shigoto922@gmail.com", "shigoto922@gmail.com"));
        msg.To.Add(new MailboxAddress(toEmail, toEmail));
        msg.Subject = subject;
        msg.Body = new TextPart("html") { Text = message };
        using (var client = new SmtpClient()){
            await client.ConnectAsync(IPAddress.Parse("192.168.11.6").ToString(), 10025, false);
            await client.SendAsync(msg);
            await client.DisconnectAsync(true);
        }
    }
}
