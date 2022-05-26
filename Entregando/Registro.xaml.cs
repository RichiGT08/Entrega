using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregando
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        IAuth auth;
        public Registro()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(txtNombre.Text,txtEmail.Text, txtCelular.Text,txtCiudad.Text, txtContra.Text);
            if (user != null)
            {
                await DisplayAlert("Exitoso", "Nuevo Usuario Registrado", "ok");
                var signOut = auth.SignOuth();

                if(signOut)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await DisplayAlert("ERROR", "datos errorenos, intente nuevamente", "OK");
                }

            }
        }
    } 
}