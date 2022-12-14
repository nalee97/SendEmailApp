using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SendEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("roman77@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("roman77@ethereal.email"));
            email.Subject = "Send Email Test";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("roman77@ethereal.email", "thRqSSYgkzEaWnHNsM");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }
    }
}
