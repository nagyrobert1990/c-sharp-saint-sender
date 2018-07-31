using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using System.Threading;

namespace SaintSender
{
    public partial class SaintSender : Form
    {
        Thread autoSyncThread;
        MailManager mailManager;

        public SaintSender()
        {
            InitializeComponent();
            mailManager = new MailManager();
            autoSyncThread = new Thread(() => InvokeAccountLoad());
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
            listViewMailboxes.BeginInvoke(new Action(() =>
            {
                listViewMailboxes.Clear();
            }));

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

                listViewMailboxes.BeginInvoke(new Action(() =>
                {
                    listViewMailboxes.Items.Add(listViewItem);
                }));
            }
        }

        private void ShowMails(IEnumerable<MailMessage> messages)
        {
            dataGVListEmails.BeginInvoke(new Action(() =>
            {
                dataGVListEmails.Rows.Clear();
            }));

            foreach (var message in messages)
            {
                DataGridViewRow row = new DataGridViewRow();
                var From = message.From;
                var Subject = message.Subject;
                var Date = message.Headers["Date"];
                var rowIndex = 0;

                dataGVListEmails.BeginInvoke(new Action(() =>
                {
                    rowIndex = dataGVListEmails.Rows.Add(new object[] { false, From, Subject, Date });
                }));

                dataGVListEmails.BeginInvoke(new Action(() =>
                {
                    dataGVListEmails.Rows[rowIndex].Tag = message;
                }));
            }

            dataGVListEmails.BeginInvoke(new Action(() =>
            {
                dataGVListEmails.Sort(dataGVListEmails.Columns[3], ListSortDirection.Ascending);
            }));
        }

        private void InvokeAccountLoad()
        {
            while (true)
            {
                AccountLoad();
                Thread.Sleep(5000);
            }
        }

        private void AccountLoad()
        {
            labelAccount.BeginInvoke(new Action(() =>
            {
                labelAccount.Text = mailManager.AccountName;
            }));
            IEnumerable<string> mailboxes = mailManager.GetMailboxes();
            ShowMailboxes(mailboxes);
            DisplayMessages();
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
                    autoSyncThread = new Thread(() => InvokeAccountLoad());
                    autoSyncThread.Start();
                    InitSignedInView();
                }
                catch (Exception)
                {
                    autoSyncThread.Abort();
                    InitLoggedOutView();
                    labelInputNotVallid.Visible = true;
                }
            }
            else if (btnSignIn.Text.Equals("Log out"))
            {
                autoSyncThread.Abort();
                InitLoggedOutView();
                mailManager.Logout();
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Tag == null)
            {
                try
                {
                    mailManager.SendNew(textBoxAddress.Text, textBoxSubject.Text, richTextBox2.Text);
                    richTextBox2.Clear();
                    textBoxAddress.Clear();
                    textBoxSubject.Clear();
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSearch.Text))
            {
                autoSyncThread.Abort();
                IEnumerable<string> mailboxes = mailManager.GetMailboxes();
                ShowMailboxes(mailboxes);
                IEnumerable<MailMessage> messages = mailManager.GetMessages(textBoxSearch.Text);
                if (messages.Count() > 0)
                {
                    ShowMails(messages);
                }
            }
            else
            {
                autoSyncThread.Start();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            autoSyncThread = new Thread(() => InvokeAccountLoad());
            autoSyncThread.Start();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                Backup backup = new Backup(username, password, mailManager.GetStringMessages());
                backup.Serialize();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                autoSyncThread.Abort();
                Backup backup = Backup.Deserialize(username, password);
                ShowMails(backup.GetMessagesFromStrings());
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }
    }
}
