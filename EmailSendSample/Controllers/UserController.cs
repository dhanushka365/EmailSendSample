using EmailSendSample.Interface;
using EmailSendSample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace EmailSendSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public UserController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("send")]
        public IActionResult SendEmail([FromBody] EmailModel emailModel)
        {
            try
            {
                // Validate the emailModel
                if (string.IsNullOrWhiteSpace(emailModel.ToEmail) || string.IsNullOrWhiteSpace(emailModel.Subject))
                {
                    return BadRequest("ToEmail and Subject are required.");
                }

                // Attempt to send the email
                _emailSender.SendEmail(emailModel.ToEmail, emailModel.Subject);

                // If sending is successful, return a success response
                return Ok("Email sent successfully");
            }
            catch (SmtpException smtpEx)
            {
                // Handle SMTP-specific exceptions
                return BadRequest("Failed to send email. SMTP error: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return BadRequest("Failed to send email: " + ex.Message);
            }
        }
    }
}
