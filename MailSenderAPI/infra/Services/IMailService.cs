﻿namespace MailSenderAPI.infra.Services
{
    public interface IMailService
    {
        void SendEmail(string[] emails, string subject, string body, bool isHtml = false);
    }
}
