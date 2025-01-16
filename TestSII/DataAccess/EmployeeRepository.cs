using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestSII.Models;

public class EmployeeRepository
{
    private readonly HttpClient _httpClient;

    public EmployeeRepository()
    {
        _httpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });
    }

    public async Task<List<EmployeeData>> GetEmployeesAsync()
    {
        var response = await _httpClient.GetStringAsync("https://hub.dummyapis.com/employee");
        return JsonConvert.DeserializeObject<List<EmployeeData>>(response);
    }

    public async Task<EmployeeData> GetEmployeeByIdAsync(int id)
    {
        try
        {
            // Crea una solicitud HTTP
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://dummy.restapiexample.com/api/v1/employee/{id}");
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error Código de estado: {response.StatusCode}");
                throw new Exception($"Error Código de estado: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<EmployeeApiResponse>(content);

            return new EmployeeData
            {
                Id = apiResponse.Data.Id,
                FirstName = apiResponse.Data.FirstName,
                Salary = apiResponse.Data.Salary,
                Age = apiResponse.Data.Age,
                Address = "N/A",
                Dob = "N/A",
                ContactNumber = "N/A",
                Email = "N/A",
                ImageUrl = apiResponse.Data.ImageUrl,
                LastName = ""
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción detectada: {ex.Message}");
            throw;
        }
    }

}
