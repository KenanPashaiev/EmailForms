namespace EmailForms
{
    partial class Form1
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
            this.templatePanel = new System.Windows.Forms.Panel();
            this.templateButton = new System.Windows.Forms.Button();
            this.templateCheckBox = new System.Windows.Forms.CheckBox();
            this.mailsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.emailPanel = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.messageBodyHtml = new System.Windows.Forms.WebBrowser();
            this.messageSubject = new System.Windows.Forms.Label();
            this.messageDate = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.messageTo = new System.Windows.Forms.Label();
            this.messageFrom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.messagesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.messageBody = new System.Windows.Forms.RichTextBox();
            this.addEmailButton = new System.Windows.Forms.Button();
            this.templatePanel.SuspendLayout();
            this.mailsFlowPanel.SuspendLayout();
            this.emailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // templatePanel
            // 
            this.templatePanel.Controls.Add(this.templateButton);
            this.templatePanel.Controls.Add(this.templateCheckBox);
            this.templatePanel.Location = new System.Drawing.Point(3, 3);
            this.templatePanel.Name = "templatePanel";
            this.templatePanel.Size = new System.Drawing.Size(240, 30);
            this.templatePanel.TabIndex = 0;
            // 
            // templateButton
            // 
            this.templateButton.Location = new System.Drawing.Point(211, 4);
            this.templateButton.Name = "templateButton";
            this.templateButton.Size = new System.Drawing.Size(26, 23);
            this.templateButton.TabIndex = 1;
            this.templateButton.Text = "X";
            this.templateButton.UseVisualStyleBackColor = true;
            // 
            // templateCheckBox
            // 
            this.templateCheckBox.Location = new System.Drawing.Point(8, 4);
            this.templateCheckBox.Name = "templateCheckBox";
            this.templateCheckBox.Size = new System.Drawing.Size(198, 24);
            this.templateCheckBox.TabIndex = 0;
            this.templateCheckBox.Text = "kenan.pashaiev@gmail.com";
            this.templateCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.templateCheckBox.UseVisualStyleBackColor = true;
            // 
            // mailsFlowPanel
            // 
            this.mailsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mailsFlowPanel.AutoScroll = true;
            this.mailsFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mailsFlowPanel.Controls.Add(this.templatePanel);
            this.mailsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mailsFlowPanel.Location = new System.Drawing.Point(0, 53);
            this.mailsFlowPanel.Name = "mailsFlowPanel";
            this.mailsFlowPanel.Size = new System.Drawing.Size(252, 484);
            this.mailsFlowPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Emails";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(12, 4);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 5;
            this.logInButton.Text = "Log in";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(0, 3);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 23);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // emailPanel
            // 
            this.emailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailPanel.BackColor = System.Drawing.SystemColors.Control;
            this.emailPanel.Controls.Add(this.logOutButton);
            this.emailPanel.Controls.Add(this.searchButton);
            this.emailPanel.Controls.Add(this.usernameLabel);
            this.emailPanel.Controls.Add(this.searchTextBox);
            this.emailPanel.Controls.Add(this.toDate);
            this.emailPanel.Controls.Add(this.messageBodyHtml);
            this.emailPanel.Controls.Add(this.messageSubject);
            this.emailPanel.Controls.Add(this.messageDate);
            this.emailPanel.Controls.Add(this.fromDate);
            this.emailPanel.Controls.Add(this.messageTo);
            this.emailPanel.Controls.Add(this.messageFrom);
            this.emailPanel.Controls.Add(this.label5);
            this.emailPanel.Controls.Add(this.label4);
            this.emailPanel.Controls.Add(this.label3);
            this.emailPanel.Controls.Add(this.label2);
            this.emailPanel.Controls.Add(this.messagesFlowPanel);
            this.emailPanel.Controls.Add(this.messageBody);
            this.emailPanel.Controls.Add(this.addEmailButton);
            this.emailPanel.Controls.Add(this.label1);
            this.emailPanel.Controls.Add(this.mailsFlowPanel);
            this.emailPanel.Location = new System.Drawing.Point(12, 30);
            this.emailPanel.Name = "emailPanel";
            this.emailPanel.Size = new System.Drawing.Size(960, 569);
            this.emailPanel.TabIndex = 7;
            this.emailPanel.Visible = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(881, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(81, 2);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(171, 24);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(670, 5);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(205, 20);
            this.searchTextBox.TabIndex = 11;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(464, 5);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(200, 20);
            this.toDate.TabIndex = 10;
            this.toDate.Value = new System.DateTime(2022, 1, 10, 0, 22, 0, 0);
            // 
            // messageBodyHtml
            // 
            this.messageBodyHtml.Location = new System.Drawing.Point(542, 90);
            this.messageBodyHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageBodyHtml.Name = "messageBodyHtml";
            this.messageBodyHtml.Size = new System.Drawing.Size(415, 476);
            this.messageBodyHtml.TabIndex = 16;
            this.messageBodyHtml.Visible = false;
            // 
            // messageSubject
            // 
            this.messageSubject.AutoSize = true;
            this.messageSubject.Location = new System.Drawing.Point(594, 74);
            this.messageSubject.Name = "messageSubject";
            this.messageSubject.Size = new System.Drawing.Size(10, 13);
            this.messageSubject.TabIndex = 15;
            this.messageSubject.Text = "-";
            // 
            // messageDate
            // 
            this.messageDate.AutoSize = true;
            this.messageDate.Location = new System.Drawing.Point(578, 60);
            this.messageDate.Name = "messageDate";
            this.messageDate.Size = new System.Drawing.Size(10, 13);
            this.messageDate.TabIndex = 14;
            this.messageDate.Text = "-";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(258, 5);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(200, 20);
            this.fromDate.TabIndex = 9;
            this.fromDate.Value = new System.DateTime(2021, 1, 4, 0, 0, 0, 0);
            // 
            // messageTo
            // 
            this.messageTo.AutoSize = true;
            this.messageTo.Location = new System.Drawing.Point(564, 47);
            this.messageTo.Name = "messageTo";
            this.messageTo.Size = new System.Drawing.Size(10, 13);
            this.messageTo.TabIndex = 13;
            this.messageTo.Text = "-";
            // 
            // messageFrom
            // 
            this.messageFrom.AutoSize = true;
            this.messageFrom.Location = new System.Drawing.Point(578, 34);
            this.messageFrom.Name = "messageFrom";
            this.messageFrom.Size = new System.Drawing.Size(10, 13);
            this.messageFrom.TabIndex = 12;
            this.messageFrom.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(542, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Subject:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "From:";
            // 
            // messagesFlowPanel
            // 
            this.messagesFlowPanel.AutoScroll = true;
            this.messagesFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.messagesFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.messagesFlowPanel.Location = new System.Drawing.Point(258, 34);
            this.messagesFlowPanel.Name = "messagesFlowPanel";
            this.messagesFlowPanel.Size = new System.Drawing.Size(278, 532);
            this.messagesFlowPanel.TabIndex = 7;
            this.messagesFlowPanel.WrapContents = false;
            // 
            // messageBody
            // 
            this.messageBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBody.Location = new System.Drawing.Point(542, 90);
            this.messageBody.Name = "messageBody";
            this.messageBody.ReadOnly = true;
            this.messageBody.Size = new System.Drawing.Size(415, 476);
            this.messageBody.TabIndex = 6;
            this.messageBody.Text = "";
            // 
            // addEmailButton
            // 
            this.addEmailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEmailButton.Location = new System.Drawing.Point(84, 543);
            this.addEmailButton.Name = "addEmailButton";
            this.addEmailButton.Size = new System.Drawing.Size(75, 23);
            this.addEmailButton.TabIndex = 5;
            this.addEmailButton.Text = "Add email";
            this.addEmailButton.UseVisualStyleBackColor = true;
            this.addEmailButton.Click += new System.EventHandler(this.addEmailButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.emailPanel);
            this.Controls.Add(this.logInButton);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "Form1";
            this.Text = "Form1";
            this.templatePanel.ResumeLayout(false);
            this.mailsFlowPanel.ResumeLayout(false);
            this.emailPanel.ResumeLayout(false);
            this.emailPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel templatePanel;
        private System.Windows.Forms.CheckBox templateCheckBox;
        private System.Windows.Forms.FlowLayoutPanel mailsFlowPanel;
        private System.Windows.Forms.Button templateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Panel emailPanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button addEmailButton;
        private System.Windows.Forms.RichTextBox messageBody;
        private System.Windows.Forms.FlowLayoutPanel messagesFlowPanel;
        private System.Windows.Forms.Label messageSubject;
        private System.Windows.Forms.Label messageDate;
        private System.Windows.Forms.Label messageTo;
        private System.Windows.Forms.Label messageFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser messageBodyHtml;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}

