using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace SaintSender
{
    [Serializable()]
    class Backup
    {
        public string Username { get; }
        public string Password { get; }
        public List<StringMail> Mails { get; }

        public Backup(string username, string password, List<StringMail> mails)
        {
            Username = username.Split('@')[0]; ;
            Password = password;
            Mails = mails;
        }

        public void Serialize()
        {
            string output = Username + ".dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(output,
                                        FileMode.Create,
                                        FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();            
        }

        public static Backup Deserialize(string username, string password)
        {
            username = username.Split('@')[0];
            username += ".dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(username,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            Backup mails = (Backup)formatter.Deserialize(stream);
            stream.Close();
            if (mails.Password.Equals(password))
            {
                return mails;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<MailMessage> GetMessagesFromStrings()
        {
            List<MailMessage> messages = new List<MailMessage>();
            foreach (StringMail stringMail in Mails)
            {
                messages.Add(stringMail.StringToMail());
            }
            return messages;
        }
    }
}
