//using Newtonsoft.Json;
//using System.Net.Http;
//using TestSII.DataAccess;
//using TestSII.Models;

//namespace TestSII.BusinessLogic
//{
//    public class EmployeeService
//    {
//        private readonly EmployeeRepository _repository;

//        public EmployeeService(EmployeeRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<List<Employee>> GetAllEmployeesWithAnnualSalaryAsync()
//        {
//            var employees = await _repository.GetAllEmployeesAsync();
//            employees.ForEach(e => e.Salary *= 12); // Calcular el salario anual
//            return employees;
//        }

//        public async Task<Employee> GetEmployeeWithAnnualSalaryByIdAsync(int id)
//        {
//            var employee = await _repository.GetEmployeeByIdAsync(id);
//            if (employee == null)
//            {
//                throw new KeyNotFoundException($"Employee with ID {id} not found.");
//            }
//            employee.Salary *= 12; // Calcular el salario anual
//            return employee;
//        }
//    }

//}
