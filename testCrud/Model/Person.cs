using System.Text.Json.Serialization;

namespace test3.Model;

public class Person
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
}