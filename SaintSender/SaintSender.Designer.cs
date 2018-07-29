namespace SaintSender
{
    partial class SaintSender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGVListEmails = new System.Windows.Forms.DataGridView();
            this.ColSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelInputNotVallid = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnCompose = new System.Windows.Forms.Button();
            this.listViewMailboxes = new System.Windows.Forms.ListView();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.labelAccount = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVListEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVListEmails
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGVListEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGVListEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelected,
            this.ColFrom,
            this.ColSubject,
            this.ColDate});
            this.dataGVListEmails.Location = new System.Drawing.Point(118, 112);
            this.dataGVListEmails.MultiSelect = false;
            this.dataGVListEmails.Name = "dataGVListEmails";
            this.dataGVListEmails.ReadOnly = true;
            this.dataGVListEmails.RowHeadersVisible = false;
            this.dataGVListEmails.RowTemplate.ReadOnly = true;
            this.dataGVListEmails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVListEmails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGVListEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVListEmails.Size = new System.Drawing.Size(802, 231);
            this.dataGVListEmails.TabIndex = 3;
            this.dataGVListEmails.Click += new System.EventHandler(this.DataGVListEmails_Click);
            // 
            // ColSelected
            // 
            this.ColSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColSelected.HeaderText = "Selected";
            this.ColSelected.Name = "ColSelected";
            this.ColSelected.ReadOnly = true;
            this.ColSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSelected.Width = 55;
            // 
            // ColFrom
            // 
            this.ColFrom.HeaderText = "From";
            this.ColFrom.Name = "ColFrom";
            this.ColFrom.ReadOnly = true;
            this.ColFrom.Width = 248;
            // 
            // ColSubject
            // 
            this.ColSubject.HeaderText = "Subject";
            this.ColSubject.Name = "ColSubject";
            this.ColSubject.ReadOnly = true;
            this.ColSubject.Width = 249;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Width = 249;
            // 
            // btnSignIn
            // 
            this.btnSignIn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSignIn.Location = new System.Drawing.Point(254, 38);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 18;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(84, 38);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(164, 20);
            this.textBoxPassword.TabIndex = 17;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelPassword.Location = new System.Drawing.Point(14, 41);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 16;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(84, 12);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(164, 20);
            this.textBoxUsername.TabIndex = 15;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelUsername.Location = new System.Drawing.Point(12, 15);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 14;
            this.labelUsername.Text = "Username";
            // 
            // labelInputNotVallid
            // 
            this.labelInputNotVallid.AutoSize = true;
            this.labelInputNotVallid.ForeColor = System.Drawing.Color.Red;
            this.labelInputNotVallid.Location = new System.Drawing.Point(81, 61);
            this.labelInputNotVallid.Name = "labelInputNotVallid";
            this.labelInputNotVallid.Size = new System.Drawing.Size(168, 13);
            this.labelInputNotVallid.TabIndex = 19;
            this.labelInputNotVallid.Text = "Username or password is not valid";
            this.labelInputNotVallid.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.Location = new System.Drawing.Point(848, 82);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Gray;
            this.btnSearch.Location = new System.Drawing.Point(118, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(196, 85);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(239, 20);
            this.textBoxSearch.TabIndex = 20;
            // 
            // btnCompose
            // 
            this.btnCompose.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnCompose.Location = new System.Drawing.Point(12, 83);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(100, 23);
            this.btnCompose.TabIndex = 23;
            this.btnCompose.Text = "Compose";
            this.btnCompose.UseVisualStyleBackColor = true;
            // 
            // listViewMailboxes
            // 
            this.listViewMailboxes.BackColor = System.Drawing.SystemColors.Window;
            this.listViewMailboxes.Location = new System.Drawing.Point(12, 112);
            this.listViewMailboxes.Name = "listViewMailboxes";
            this.listViewMailboxes.Size = new System.Drawing.Size(100, 231);
            this.listViewMailboxes.TabIndex = 24;
            this.listViewMailboxes.UseCompatibleStateImageBehavior = false;
            this.listViewMailboxes.View = System.Windows.Forms.View.List;
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.Location = new System.Drawing.Point(12, 407);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 25;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnReply
            // 
            this.btnReply.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnReply.Location = new System.Drawing.Point(12, 436);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(100, 23);
            this.btnReply.TabIndex = 26;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.BtnReply_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(118, 407);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(802, 227);
            this.richTextBox2.TabIndex = 28;
            this.richTextBox2.Text = "";
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelAccount.Location = new System.Drawing.Point(352, 31);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAccount.Size = new System.Drawing.Size(54, 23);
            this.labelAccount.TabIndex = 29;
            this.labelAccount.Text = "Account";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(118, 349);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(802, 20);
            this.textBoxAddress.TabIndex = 30;
            this.textBoxAddress.Click += new System.EventHandler(this.TextBoxAddress_Click);
            this.textBoxAddress.TextChanged += new System.EventHandler(this.TextBoxAddress_TextChanged);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(118, 380);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(802, 20);
            this.textBoxSubject.TabIndex = 31;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAddress.Location = new System.Drawing.Point(36, 352);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 32;
            this.lblAddress.Text = "From/To";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSubject.Location = new System.Drawing.Point(36, 381);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 33;
            this.lblSubject.Text = "Subject";
            // 
            // SaintSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 666);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listViewMailboxes);
            this.Controls.Add(this.btnCompose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelInputNotVallid);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.dataGVListEmails);
            this.Name = "SaintSender";
            this.Text = "SaintSender";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVListEmails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVListEmails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelInputNotVallid;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.ListView listViewMailboxes;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSubject;
    }
}

