using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailForms.BL.Models;

namespace EmailForms
{
    public partial class LogInForm : Form
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 24;
        private const int MinPasswordLength = 8;
        private const int MaxPasswordLength = 32;

        private Func<UserLoginDto, Task<bool>> LogIn;
        private Func<UserLoginDto, Task<bool>> Register;

        public LogInForm(Func<UserLoginDto, Task<bool>> logIn, Func<UserLoginDto, Task<bool>> register)
        {
            InitializeComponent();
            LogIn = logIn;
            Register = register;
        }

        private async void logInButton_Click(object sender, EventArgs e)
        {
            if(!ValidateCredentials())
            {
                return;
            }

            var userDto = new UserLoginDto
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text
            };

            loadingLabel.Visible = true;
            panel1.Visible = false;
            var loginResult = await LogIn(userDto);
            loadingLabel.Visible = false;
            panel1.Visible = true;
            if (!loginResult)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }
            Hide();
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            if (!ValidateCredentials())
            {
                return;
            }

            var userDto = new UserLoginDto
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text
            };

            loadingLabel.Visible = true;
            panel1.Visible = false;
            var registerResult = await Register(userDto);
            loadingLabel.Visible = false;
            panel1.Visible = true;
            if (!registerResult)
            {
                MessageBox.Show($"A user with the username '{userDto.Username} already exists'");
                return;
            }

            Hide();
        }

        private bool ValidateCredentials()
        {
            var username = usernameTextBox.Text;
            if (string.IsNullOrWhiteSpace(username) || username.Length < MinUsernameLength || username.Length > MaxUsernameLength)
            {
                MessageBox.Show($"Username should be between {MinUsernameLength} and {MaxUsernameLength}");
                return false;
            }
            if(username.Contains(' '))
            {
                MessageBox.Show($"Username can't contain whitespace");
                return false;
            }

            var password = passwordTextBox.Text;
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength || password.Length > MaxPasswordLength)
            {
                MessageBox.Show($"Password should be between {MinPasswordLength} and {MaxPasswordLength}");
                return false;
            }
            if (password.Contains(' '))
            {
                MessageBox.Show($"Password can't contain whitespace");
                return false;
            }

            return true;
        }
    }
}
