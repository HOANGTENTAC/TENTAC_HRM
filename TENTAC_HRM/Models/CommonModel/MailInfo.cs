using System;

namespace TENTAC_HRM.Models.CommonModel
{
    public class MailInfo
    {
        public MailInfo(string emailAddress, string password, string subject, string TextBody, string emailTest)
        {
            this.EmailAddress = emailAddress;
            this.Password = password;
            this.Subject = subject;
            this.TextBody = TextBody;
            this.EmailTest = emailTest;
        }

        public string EmailAddress { get; set; }
        public string EmailTest { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }

        public override string ToString()
        {
            return $"EmailAddress: {EmailAddress};" + Environment.NewLine +
                   $"Password: {Password};" + Environment.NewLine +
                   $"Subject: {Subject};" + Environment.NewLine +
                   $"TextBody: {TextBody};" + Environment.NewLine +
                   $"EmailTest: {EmailTest};";
        }
    }
}
