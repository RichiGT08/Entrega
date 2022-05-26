using Entregando.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregando.Services
{
    public class EmployeeService : IEmployeeService
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseSeceret)
        });

        public async Task<bool> AddOrUpdateEmployee(employeeModel employeeModel)
        {
            if (!string.IsNullOrWhiteSpace(employeeModel.key))
            {
                try
                {
                    await firebase.Child(nameof(employeeModel)).Child(employeeModel.key).PutAsync(employeeModel);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(employeeModel)).PostAsync(employeeModel);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<bool> DeleteEmployee(string key)
        {
            try
            {
                await firebase.Child(nameof(employeeModel)).Child(key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<employeeModel>> GetAllEmployee()
        {
            return (await firebase.Child(nameof(employeeModel)).OnceAsync<employeeModel>()).Select(f => new employeeModel
            {
                Destinatario = f.Object.Destinatario,
                Direccion = f.Object.Direccion,
                Celular = f.Object.Celular,
                Posicion = f.Object.Posicion,
                Estado = f.Object.Estado,
                key = f.Object.key
               
            }).ToList();

        }
    }
}