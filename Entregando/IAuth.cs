using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entregando
{
    public interface IAuth
    {
        Task<string> LoginWhithEmailAndPassword(string email, string contra);
        Task<string> SignUpWithEmailAndPassword(string nombre,string email, string celular,string ciudad, string contra );

        bool SignOuth();
        bool IsSigIn();

    }
}
