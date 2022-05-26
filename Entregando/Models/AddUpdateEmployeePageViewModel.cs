using Entregando.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Entregando.Models
{
    public class AddUpdateEmployeePageViewModel 
    {
        #region Properties
        private readonly IEmployeeService _employeeService;

        private employeeModel _employeeDetail = new employeeModel();
        public employeeModel EmployeeDetail
        {
            get => _employeeDetail;
            set => SetProperty(ref _employeeDetail, value);
        }

        private void SetProperty(ref employeeModel employeeDetail, employeeModel value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructor
        public AddUpdateEmployeePageViewModel()
        {
            _employeeService = DependencyService.Resolve<IEmployeeService>();
        }

        public AddUpdateEmployeePageViewModel(employeeModel employeeResponse)
        {
            _employeeService = DependencyService.Resolve<IEmployeeService>();
            EmployeeDetail = new employeeModel
            {
                Destinatario= employeeResponse.Destinatario,
                Direccion= employeeResponse.Direccion,
                Celular= employeeResponse.Celular,
                Posicion= employeeResponse.Posicion,
                Estado= employeeResponse.Estado,
                key= employeeResponse.key
            };
        }
        #endregion

        #region Commands
        public ICommand SaveEmployeeCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            bool res = await _employeeService.AddOrUpdateEmployee(EmployeeDetail);
            if (res)
            {

                if (!string.IsNullOrWhiteSpace(EmployeeDetail.key))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Record Updated successfully.", "Ok");
                }
                else
                {
                    EmployeeDetail = new employeeModel() { };
                    await App.Current.MainPage.DisplayAlert("Success!", "Record added successfully.", "Ok");
                }
            }
            IsBusy = false;
        });

        public bool IsBusy { get; private set; }
        #endregion
    }
}