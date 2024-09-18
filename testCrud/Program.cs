using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using test3.Model;
using test3.Service;

// PersonService service = new PersonService();
// Console.WriteLine(await service.DeletePerson(2));

using HttpClient client = new HttpClient();
    
HttpResponseMessage response = client.DeleteAsync($"http://localhost:5132/Person/1").Result;

if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Patient deleted successfully");
}
else
{
    Console.WriteLine("Deleting was not successful");
}