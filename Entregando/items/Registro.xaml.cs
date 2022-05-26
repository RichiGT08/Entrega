using Entregando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregando.items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUpdateEmployee : ContentPage
    {
        public AddUpdateEmployee()
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateEmployeePageViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public AddUpdateEmployee(employeeModel employee)
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateEmployeePageViewModel(employee);
        }
    }
}