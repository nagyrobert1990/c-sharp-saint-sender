using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SaintSender
{
    [Serializable()]
    class StringMail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public StringMail(string from, string to, string subject, string body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
        }

        public static StringMail MailToString(MailMessage mail)
        {
            StringMail stringMail = null;
            stringMail = new StringMail(mail.From.ToString(), mail.To.ToString(), mail.Subject, mail.Body);
            return stringMail;
        }

        public MailMessage StringToMail()
        {
            MailMessage mailMessage = new MailMessage(From, To, Subject, Body);
            return mailMessage;
        }
    }
}
