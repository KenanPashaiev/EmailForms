using EmailForms.DAL;
using SimpleInjector;
using System;
using System.Windows.Forms;
using EmailForms.BL.Abstractions;
using EmailForms.BL.Services;
using MailKit.Net.Imap;

namespace EmailForms
{
    static class Program
    {
        private const string ConnectionString = @"Server=tcp:kenan-server.database.windows.net,1433;Initial Catalog=kenan-pashaiev;Persist Security Info=False;User ID=kenan.pashaiev;Password=Tesco2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static Container Container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(new Form1(Container.GetInstance<IUserService>(),
                Container.GetInstance<IMailService>(), Container.GetInstance<IImapService>()));
        }

        private static void Bootstrap()
        {
            Container = new Container();

            Container.Register<MailRepository>();
            Container.Register<UserRepository>();
            Container.Register<IMailService, MailService>();
            Container.Register<IUserService, UserService>();
            Container.Register<IImapService, ImapService>();

            Container.RegisterInitializer<UserRepository>(instance =>
                instance.Init(ConnectionString));
            Container.RegisterInitializer<MailRepository>(instance =>
                instance.Init(ConnectionString));

            Container.Verify();
        }
    }
}
