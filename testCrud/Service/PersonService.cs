using test3.Model;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace test3.Service;

public class PersonService
{
    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5132/Person");

        HttpResponseMessage res = client.Send(request);
        string content = await res.Content.ReadAsStringAsync();

        IEnumerable<Person>? people = JsonSerializer.Deserialize<IEnumerable<Person>>(content);
        return people!;
    }

    public async Task<Person> GetPersonById(int id)
    {
        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5132/Person/{id}");

        HttpResponseMessage res = client.Send(request);
        string content = await res.Content.ReadAsStringAsync();

        Person? person = JsonSerializer.Deserialize<Person>(content);
        return person!;
    }

    public async Task<bool> CreatePerson(Person person)
    {
        HttpClient client = new HttpClient();

        JsonContent content =  JsonContent.Create(person);

        HttpResponseMessage response = await client.PostAsync("http://localhost:5132/Person", content);

        if (response.StatusCode==HttpStatusCode.OK)
        {
            Console.WriteLine("Person created successfully");
            string con = await response.Content.ReadAsStringAsync();
            Console.WriteLine(con);
            return true;
        }
        else
        {
            Console.WriteLine("Person creation failed");
            return false;
        }
    }

    public async Task<bool> UpdatePerson(Person person)
    {
        HttpClient client = new HttpClient();

        JsonContent content =  JsonContent.Create(person);

        HttpResponseMessage response = await client.PutAsync("http://localhost:5132/Person", content);

        if (response.StatusCode==HttpStatusCode.OK)
        {
            Console.WriteLine("Person updated successfully");
            string con = await response.Content.ReadAsStringAsync();
            Console.WriteLine(con);
            return true;
        }
        else
        {
            Console.WriteLine("Person updation failed");
            return false;
        }
    }

    public async Task<bool> UpdatePersonWithPatch(Person person)
    {
        HttpClient client = new HttpClient();

        JsonContent content =  JsonContent.Create(person);

        HttpResponseMessage response = await client.PatchAsync("http://localhost:5132/Person", content);

        if (response.StatusCode==HttpStatusCode.OK)
        {
            Console.WriteLine("Person updated with patch successfully");
            string con = await response.Content.ReadAsStringAsync();
            Console.WriteLine(con);
            return true;
        }
        else
        {
            Console.WriteLine("Person updation with patch failed");
            return false;
        }
    }

    public async Task<bool> DeletePerson(int id)
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.DeleteAsync($"http://localhost:5132/Person/{id}");

        if (response.StatusCode==HttpStatusCode.OK)
        {
            Console.WriteLine("Person deleted successfully");
            return true;
        }
        else
        {
            Console.WriteLine($"Person deletion failed {response.StatusCode}");
            return false;
        }
    }
}