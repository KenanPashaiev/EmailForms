namespace EmailForms.Controls
{
    partial class MessagePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.templateMessageSubjectLabel = new System.Windows.Forms.Label();
            this.templateMessageFromLabel = new System.Windows.Forms.Label();
            this.templateMessageDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // templateMessageSubjectLabel
            // 
            this.templateMessageSubjectLabel.Location = new System.Drawing.Point(3, 18);
            this.templateMessageSubjectLabel.Name = "templateMessageSubjectLabel";
            this.templateMessageSubjectLabel.Size = new System.Drawing.Size(244, 30);
            this.templateMessageSubjectLabel.TabIndex = 5;
            this.templateMessageSubjectLabel.Text = "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss" +
    "ssssssssssssssssssssssssssssssssssssssssssss";
            // 
            // templateMessageFromLabel
            // 
            this.templateMessageFromLabel.Location = new System.Drawing.Point(72, 5);
            this.templateMessageFromLabel.Name = "templateMessageFromLabel";
            this.templateMessageFromLabel.Size = new System.Drawing.Size(175, 13);
            this.templateMessageFromLabel.TabIndex = 4;
            this.templateMessageFromLabel.Text = "Kenan Pashaiev";
            this.templateMessageFromLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // templateMessageDateLabel
            // 
            this.templateMessageDateLabel.Location = new System.Drawing.Point(4, 5);
            this.templateMessageDateLabel.Name = "templateMessageDateLabel";
            this.templateMessageDateLabel.Size = new System.Drawing.Size(62, 13);
            this.templateMessageDateLabel.TabIndex = 3;
            this.templateMessageDateLabel.Text = "12-30-2021";
            // 
            // MessagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.templateMessageSubjectLabel);
            this.Controls.Add(this.templateMessageFromLabel);
            this.Controls.Add(this.templateMessageDateLabel);
            this.Name = "MessagePanel";
            this.Size = new System.Drawing.Size(250, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label templateMessageSubjectLabel;
        private System.Windows.Forms.Label templateMessageFromLabel;
        private System.Windows.Forms.Label templateMessageDateLabel;
    }
}
