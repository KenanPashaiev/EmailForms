using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailForms.BL.Abstractions;
using EmailForms.BL.Models;
using EmailForms.Controls;
using IMailService = EmailForms.BL.Abstractions.IMailService;

namespace EmailForms
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IImapService _imapService;

        private UserDto _userDto;

        public Form1(IUserService userService, IMailService mailService, IImapService imapService)
        {
            InitializeComponent();
            _userService = userService;
            _mailService = mailService;
            _imapService = imapService;
            //MockUser();
            UpdateInterface();
        }
        
        private async Task<bool> LogIn(UserLoginDto userLoginDto)
        {
            var userDto = await _userService.LogIn(userLoginDto);
            if(userDto == default)
            {
                return false;
            }

            _userDto = userDto;
            await UpdateInterface();
            return true;
        }

        private async Task<bool> Register(UserLoginDto userLoginDto)
        {
            var registerResult = await _userService.Register(userLoginDto);
            if(registerResult)
            {
                var userDto = await _userService.LogIn(userLoginDto);
                if(userDto == default)
                {
                    return false;
                }

                _userDto = userDto;
                await UpdateInterface();
                return true;
            }

            return false;
        }

        private async Task<string> AddMail(MailCreateDto mailCreateDto)
        {
            var validationError = await _imapService.ValidateCredentials(mailCreateDto);
            if (validationError != default)
            {
                return validationError;
            }

            if (_userDto.Mails.FirstOrDefault(mail => mail.Name == mailCreateDto.Name) != null)
            {
                return $"{mailCreateDto.Name} is already added to the list";
            }

            var result = await _mailService.AddMail(_userDto.Username, mailCreateDto);
            if (!result)
            {
                return "Failed to add mail";
            }

            await UpdateInterface();
            return default;
        }

        private async Task UpdateInterface()
        {
            if(_userDto == default)
            {
                usernameLabel.Text = "";
                logInButton.Text = "Log in";
                emailPanel.Visible = false;;
            }
            else
            {
                usernameLabel.Text = $"Hi, {_userDto.Username}!";
                logInButton.Text = "Refresh";
                emailPanel.Visible = true;
                await RefreshRegisteredEmails();
                await RefreshEmails();
            }
        }

        private async Task RefreshEmails()
        {
            LoadingEmails();
            try
            {
                foreach (var mail in _userDto.Mails)
                {
                    if (!string.IsNullOrWhiteSpace(mail.Server))
                    {
                        mail.Messages = (await _imapService.GetAllSubjects(mail, true)).Select(msg => new MailMessage
                        {
                            Id = msg.UniqueId,
                            Date = msg.Date.DateTime,
                            Subject = msg.NormalizedSubject,
                            From = msg.Envelope.From.ToString(),
                            MailId = mail.Id
                        }).ToArray();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateEmailsWindow();
        }

        private void LoadingEmails()
        {
            messagesFlowPanel.Controls.Clear();
            messagesFlowPanel.Controls.Add(new Label
            {
                Text = "Loading",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(250, 30)
            });
        }

        private void UpdateEmailsWindow()
        {
            var messages = _userDto.Mails.Where(mail => mail.IsSelected).SelectMany(mail => mail.Messages);
            var filteredMessages = messages.Where(message =>
                fromDate.Value <= message.Date && toDate.Value >= message.Date && (message.From + message.Subject).Contains(searchTextBox.Text))
                .OrderByDescending(msg => msg.Date).ToArray();
            messagesFlowPanel.Controls.Clear();
            if (_userDto?.Mails == null || !_userDto.Mails.Any() || !filteredMessages.Any())
            {
                messagesFlowPanel.Controls.Add(new Label
                {
                    Text = "Empty",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(250, 30)
                });
                return;
            }

            foreach (var message in filteredMessages)
            {
                var messagePanel = new MessagePanel(message);
                messagePanel.DoubleClick += async (sender, e) => await SetMessageWindow(message);
                messagesFlowPanel.Controls.Add(messagePanel);
            }
        }

        private async Task SetMessageWindow(MailMessage mailMessage)
        {
            LoadingMessage();
            var message = await _imapService.GetMessage(_userDto.Mails.Single(mail => mail.Id == mailMessage.MailId),
                true, mailMessage.Id);
            messageBodyHtml.Visible = false;
            messageFrom.Text = message.From.ToString();
            messageTo.Text = message.To.ToString();
            messageDate.Text = message.Date.DateTime.ToShortDateString();
            messageSubject.Text = message.Subject;
            messageBody.Text = message.TextBody;
            if (string.IsNullOrWhiteSpace(message.TextBody) && !string.IsNullOrWhiteSpace(message.HtmlBody))
            {
                messageBodyHtml.Visible = true;
                messageBodyHtml.DocumentText = message.HtmlBody;
            }
        }

        private void LoadingMessage()
        {
            messageFrom.Text = string.Empty;
            messageTo.Text = string.Empty;
            messageDate.Text = string.Empty;
            messageSubject.Text = string.Empty;
            messageBody.Text = "Loading";
            messageBodyHtml.Visible = false;
        }

        private async Task RefreshRegisteredEmails()
        {
            _userDto.Mails = await _mailService.GetAllMailsForUser(_userDto.Username);
            UpdateRegisteredEmailsWindow();
        }

        private void UpdateRegisteredEmailsWindow()
        {
            mailsFlowPanel.Controls.Clear();
            if (_userDto?.Mails == null || !_userDto.Mails.Any())
            {
                return;
            }

            foreach(var mail in _userDto.Mails)
            {
                var panel = new Panel 
                {
                    Size = templatePanel.Size
                };

                var checkBox = new CheckBox
                {
                    Size = templateCheckBox.Size,
                    Location = templateCheckBox.Location,
                    TextAlign = templateCheckBox.TextAlign,
                    Text = mail.Name,
                    Checked = true
                };

                checkBox.CheckedChanged += (sender, e) =>
                {
                    mail.IsSelected = checkBox.Checked;
                    UpdateEmailsWindow();
                };

                var button = new Button
                {
                    Size = templateButton.Size,
                    Location = templateButton.Location,
                    Text = templateButton.Text
                };
                button.Click += async (sender, e) => {
                    await _mailService.DeleteMail(mail.Id);
                    await UpdateInterface();
                    };

                panel.Controls.Add(checkBox);
                panel.Controls.Add(button);
                mailsFlowPanel.Controls.Add(panel);
            }
        }

        private void LoadingRegisteredEmailsWindow()
        {
            mailsFlowPanel.Controls.Clear();
            mailsFlowPanel.Controls.Add(new Label
            {
                Text = "Loading",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(templateCheckBox.Size.Width, 30)
            });
        }

        private void MockUser()
        {
            _userDto = new UserDto
            {
                Username = "John Doe",
                Mails = new[]
                {
                    new MailDto
                    {
                        Id = Guid.NewGuid(),
                        IsSelected = true,
                        Name = "spz.john.doe@hotmail.com",
                        Password = "spzjohndoe.password",
                        Server = "outlook.office365.com"
                    },
                    new MailDto
                    {
                        Id = Guid.NewGuid(),
                        IsSelected = true,
                        Name = "spz.robert.peterson@hotmail.com",
                        Password = "spzrobertpeterson.password",
                        Server = "outlook.office365.com"
                    }

                }.ToList()
            };

        }

        private async void addEmailButton_Click(object sender, EventArgs e)
        {
            var form = new AddMailForm(AddMail);
            form.Show();
        }

        private async void logInButton_Click(object sender, EventArgs e)
        {
            if (_userDto == default)
            {
                var form = new LogInForm(LogIn, Register);
                form.Show();
            }
            await UpdateInterface();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateEmailsWindow();
        }

        private async void logOutButton_Click(object sender, EventArgs e)
        {
            _userDto = null;
            await UpdateInterface();
        }
    }
}
