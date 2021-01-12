using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailForms.BL.Models;

namespace EmailForms
{
    public partial class AddMailForm : Form
    {
        private Func<MailCreateDto, Task<string>> AddMail;

        public AddMailForm(Func<MailCreateDto, Task<string>> addMail)
        {
            InitializeComponent();
            AddMail = addMail;
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var mailCreateDto = new MailCreateDto
            {
                Server = serverTextBox.Text,
                Name = nameTextBox.Text,
                Password = passwordTextBox.Text
            };

            loadingLabel.Visible = true;
            panel1.Visible = false;
            var addMailError = await AddMail(mailCreateDto);
            loadingLabel.Visible = false;
            panel1.Visible = true;
            if (addMailError != default)
            {
                MessageBox.Show(addMailError);
                return;
            }

            Hide();
        }
    }
}
