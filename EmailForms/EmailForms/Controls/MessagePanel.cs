using System;
using System.Globalization;
using System.Windows.Forms;
using EmailForms.BL.Models;

namespace EmailForms.Controls
{
    public partial class MessagePanel : UserControl
    {
        public MessagePanel(MailMessage message)
        {
            InitializeComponent();
            templateMessageDateLabel.Text = message.Date.ToString(CultureInfo.CurrentCulture);
            templateMessageFromLabel.Text = message.From;
            templateMessageSubjectLabel.Text = message.Subject;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.DoubleClick += Control_DoubleClick;
            base.OnControlAdded(e);
        }

        void Control_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
    }
}
