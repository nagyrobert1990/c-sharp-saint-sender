using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using S22.Imap;

namespace SaintSender
{
    class MailManager
    {
        public string AccountName { get; set; }
        public bool IsSignedIn { get; set; }
        string Username;
        string Password;
        private string hostname;
        private ImapClient client;

        public MailManager()
        {
            hostname = "imap.gmail.com";
        }

        public void InitAccount(string username, string password)
        {
            if (!Regex.IsMatch(username, @"@"))
            {
                Username = username + "@gmail.com";
            }
            else
            {
                Username = username;
            }
            AccountName = username.Split('@')[0];
            Password = password;

            client = new ImapClient(hostname, 993, Username, Password, AuthMethod.Login, true);
        }

        public void Logout()
        {
            Username = null;
            Password = null;
            client.Logout();
        }

        public IEnumerable<MailMessage> GetMessages()
        {
            IEnumerable<MailMessage> messages;
            using (client)
            {
                IEnumerable<uint> uids = client.Search(SearchCondition.All());
                messages = client.GetMessages(uids.ToArray());
            }

            return messages;
        }

        public IEnumerable<MailMessage> GetMessages(string pattern)
        {
            IEnumerable<MailMessage> messages;
            using (client)
            {
                IEnumerable<uint> uids = client.Search(SearchCondition.From(pattern).Or(SearchCondition.Subject(pattern)));
                messages = client.GetMessages(uids.ToArray());
            }
            return messages;
        }

        public IEnumerable<string> GetMailboxes()
        {
            using (client)
            {
                IEnumerable<string> mailboxes = client.ListMailboxes();
                return mailboxes;
            }
        }

        public MailMessage CreateReply(MailMessage originalMail, string newMail)
        {
            MailMessage reply = new MailMessage(new MailAddress(Username, AccountName), originalMail.From);
            string id = originalMail.Headers["Message-ID"];
            reply.Headers.Add("In-Reply-To", id);
            string references = originalMail.Headers["References"];

            if (!string.IsNullOrEmpty(references))
                references += ' ';

            reply.Headers.Add("References", references + id);
            if (!originalMail.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
                reply.Subject = "Re: ";

            reply.Subject += originalMail.Subject;

            StringBuilder body = new StringBuilder();

            body.Append(newMail);
            if (originalMail.Headers["Date"].Length != 0)
                body.AppendFormat("On {0}, ", originalMail.Headers["Date"].ToString(CultureInfo.InvariantCulture));

            body.Append(originalMail.From);
            body.AppendLine(" wrote:");

            if (!string.IsNullOrEmpty(originalMail.Body))
            {
                body.AppendLine();
                body.Append("> " + originalMail.Body.Replace("\r\n", "\r\n> "));
            }
            reply.Body = body.ToString();

            return reply;
        }

        public MailMessage CreateMail(string addressTo, string subject, string mail)
        {
            MailMessage message = new MailMessage(new MailAddress(Username), new MailAddress(addressTo));
            message.Subject = subject;

            StringBuilder body = new StringBuilder();
            body.Append(mail);
            message.Body = body.ToString();

            return message;
        }

        internal void SendReply(MailMessage originalMail, string newMailText)
        {
            MailMessage message = CreateReply(originalMail, newMailText);
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                // Set SMTP client properties 
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Username, Password);
                client.DeliveryFormat = SmtpDeliveryFormat.International;

                client.Send(message);
                message.Dispose();
            }
        }

        internal void SendNew(string addressTo, string subject, string mail)
        {
            MailMessage message = CreateMail(addressTo, subject, mail);
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                // Set SMTP client properties 
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Username, Password);
                client.DeliveryFormat = SmtpDeliveryFormat.International;

                client.Send(message);
                message.Dispose();
            }
        }
    }
}
