using System.Web.Http;
using TestSII.Models;

public class EmployeeApiController : ApiController
{
    private readonly EmployeeRepository _repository = new EmployeeRepository();
    private readonly BusinessLogic _businessLogic = new BusinessLogic();

    [HttpGet]
    [Route("api/employees")]
    public async Task<IHttpActionResult> GetEmployees()
    {
        var employees = await _repository.GetEmployeesAsync();

        // Calcula el salario anual para cada empleado
        employees.ForEach(emp => emp.Salary = _businessLogic.CalculateAnnualSalary(emp.Salary));

        return Ok(employees);
    }

    [HttpGet]
    [Route("api/employee/{id}")]
    public async Task<IHttpActionResult> GetEmployeeById(int id)
    {
        var employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound();

        // Calcula el salario anual para el empleado
        employee.Salary = _businessLogic.CalculateAnnualSalary(employee.Salary);

        return Ok(employee);
    }
}
