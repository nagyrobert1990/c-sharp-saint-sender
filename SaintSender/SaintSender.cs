using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22.Imap;
using System.Net;
using Google.Apis.Gmail.v1.Data;
using System.Net.Mail;
using System.Threading;

namespace SaintSender
{
    public partial class SaintSender : Form
    {
        Task task;
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;
        MailManager mailManager;

        public SaintSender()
        {
            InitializeComponent();
            mailManager = new MailManager();
            //task = new Task(Account_Load, token);
            token = tokenSource.Token;
            task = Task.Factory.StartNew(() => Account_Load(), token);
        }

        private void InitLoggedOutView()
        {
            btnSignIn.Text = "Sign in";
            labelAccount.Text = "Account";

            textBoxSearch.Clear();
            dataGVListEmails.Rows.Clear();
            richTextBox2.Clear();
            listViewMailboxes.Clear();
        }

        private void InitSignedInView()
        {
            btnSignIn.Text = "Log out";

            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        private void ShowMailboxes(IEnumerable<string> mailboxes)
        {
            foreach (var mailbox in mailboxes)
            {
                string mailboxName = mailbox;
                if (!mailbox.Equals("INBOX"))
                {
                    mailboxName = mailbox.Substring(mailbox.IndexOf('/') + 1);
                }
                ListViewItem listViewItem = new ListViewItem(mailboxName)
                {
                    Tag = mailbox
                };
                listViewMailboxes.Items.Add(listViewItem);
            }
        }

        private void ShowMails(IEnumerable<MailMessage> messages)
        {
            int counter = 0;
            dataGVListEmails.Rows.Clear();
            foreach (var message in messages)
            {
                DataGridViewRow row = new DataGridViewRow();
                var From = message.From;
                var Subject = message.Subject;
                var Date = message.Headers["Date"];
                var rowIndex = dataGVListEmails.Rows.Add(new object[] { false, From, Subject, Date });
                dataGVListEmails.Rows[rowIndex].Tag = message;
                counter++;
            }
            dataGVListEmails.Sort(dataGVListEmails.Columns[3], ListSortDirection.Ascending);
        }

        private void Account_Load()
        {
            DisplayMessages();
            labelAccount.Text = mailManager.AccountName;
            IEnumerable<string> mailboxes = mailManager.GetMailboxes();
            ShowMailboxes(mailboxes);
            while (true)
            {
                DisplayMessages();
                task.Wait(5000);
            }
        }

        private void DisplayMessages()
        {
            IEnumerable<MailMessage> messages = mailManager.GetMessages();
            ShowMails(messages);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;
            if (btnSignIn.Text.Equals("Sign in")) {
                try
                {
                    mailManager.InitAccount(Username, Password);
                    task.Start();
                    InitSignedInView();
                }
                catch (Exception)
                {
                    InitLoggedOutView();
                    labelInputNotVallid.Visible = true;
                }
            }
            else if (btnSignIn.Text.Equals("Log out"))
            {
                InitLoggedOutView();
                tokenSource.Cancel();
                tokenSource.Dispose();
                mailManager.Logout();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DisplayMessages();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Tag == null)
            {
                try
                {
                    mailManager.SendNew(textBoxAddress.Text, textBoxSubject.Text, richTextBox2.Text);
                    richTextBox2.Clear();
                    MessageBox.Show("Message sent!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnReply_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Tag != null)
            {
                try
                {
                    mailManager.SendReply((MailMessage)richTextBox2.Tag, richTextBox2.Text);
                    richTextBox2.Clear();
                    MessageBox.Show("Message sent!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show(@"It's a new message so you can't reply!");
            }
        }

        private void DataGVListEmails_Click(object sender, EventArgs e)
        {
            MailMessage message = (MailMessage)dataGVListEmails.SelectedRows[0].Tag;
            textBoxAddress.Text = message.From.ToString();
            textBoxSubject.Text = message.Subject;
            richTextBox2.Text = message.Body;
            richTextBox2.Tag = message;
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Tag = null;
        }

        private void TextBoxAddress_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show(@"If you change the this email address you won't be able to reply!");
            }
        }
    }
}
