using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TestSII.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repository = new EmployeeRepository();

        public async Task<ActionResult> Index(int? id)
        {
            if (id.HasValue)
            {
                var employee = await _repository.GetEmployeeByIdAsync(id.Value);
                return View("EmployeeDetail", employee); // Asegúrate de que la vista existe
            }

            var employees = await _repository.GetEmployeesAsync();
            return View(employees); // Asegúrate de que la vista existe
        }
    }
}
