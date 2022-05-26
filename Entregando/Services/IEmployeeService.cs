using Entregando.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entregando.Services
{ 
 public interface IEmployeeService
{
    Task<bool> AddOrUpdateEmployee(employeeModel employeeModel);
    Task<bool> DeleteEmployee(string key);
    Task<List<employeeModel>> GetAllEmployee();
}
}
