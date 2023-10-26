using MailSenderAPI.infra.Services;
using MailSenderAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderAPI.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService) 
        {
            _mailService= mailService;

        }

        [HttpPost]
        public IActionResult SendMail([FromBody] SendMailViewModel sendMailViewModel)
        { 
         _mailService.SendEmail(sendMailViewModel.Emails, sendMailViewModel.Subject, sendMailViewModel.Body, sendMailViewModel.IsHtml);
       
        
            return Ok();
        }
    }
}
