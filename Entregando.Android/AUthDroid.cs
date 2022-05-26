using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using Entregando.Droid;

[assembly : Dependency(typeof(AUthDroid))]
namespace Entregando.Droid
{
    public class AUthDroid : IAuth
    {
        public bool IsSigIn()
        {
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWhithEmailAndPassword(string email, string contra)
        {
            try
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, contra);
                var token = user.User;
                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {

                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public bool SignOuth()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public async Task<string> SignUpWithEmailAndPassword(string nombre,string email,string celular,string ciudad, string contra)
        {
            try
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, contra);
                var token = user.User;
                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {

                e.PrintStackTrace();
                return string.Empty;
            }
        }
    }
}