using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Entregando
{
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWhithEmailAndPassword(txtEmail.Text, txtContra.Text);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new menu();

            }
            else
            {
                await DisplayAlert("Error en los Datos", "correo / Contraseña Incorrecto", "OK");
            }
        }

        async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOuth();
            if (signOut)
            {
                Application.Current.MainPage = new Registro();
            }
        }
    }
}
