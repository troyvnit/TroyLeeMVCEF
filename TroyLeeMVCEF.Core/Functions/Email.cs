using System;

namespace TroyLeeMVCEF.Core.Functions
{
    using System.Net.Mail;

    public class Email
    {
        private MailMessage m;
        private string fromAddress;
        private string toAddress;
        private string username;
        private string password;

        public Email(string fromAddress, string toAddress, string username, string password, string subject, string body)
        {
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
            this.username = username;
            this.password = password;

            m = new MailMessage();
            from = fromAddress;
            to = "troyuit@yahoo.com.vn";
            this.subject = subject;
            this.body = body;
            m.IsBodyHtml = true;
        }

        public bool isHTML
        {
            set
            {
                m.IsBodyHtml = value;
            }
        }

        public string to
        {
            set
            {
                m.To.Add(value);
            }
        }

        public string from
        {
            set
            {
                m.Sender = m.From = new MailAddress(value);
            }
        }
        public string subject
        {
            set
            {
                m.Subject = value;
            }
        }

        public string body
        {
            get
            {
                return body;
            }
            set
            {
                m.Body = value;

            }
        }

        public bool send()
        {
            try
            {
                var sc = new SmtpClient { Host = toAddress, DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false, Port = 587, Credentials = new System.Net.NetworkCredential(username, password), EnableSsl = true };
                sc.Send(m);
                return true;
            }
            catch (Exception e)
            {
                //Log error somehow
                return false;
            }
        }
    }
}
