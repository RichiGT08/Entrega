using Entregando.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregando
{
    public partial class App : Application
    {
        IAuth auth;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IEmployeeService, EmployeeService>();

            auth = DependencyService.Get<IAuth>();
            if (auth.IsSigIn())
            {
                MainPage = new menu();
            }
            else
            {
                MainPage = new MainPage();
            }

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
