#:package NewtonSoft.Json@13.0.3
#:property PublishAot=false
/// <summary>File-based modda varsayýlan Native AOT, reflection ile JsonSerializer kullanýmýný kýrdýðýndan dolayý false'a çekildi.</summary>

using micJson = System.Text.Json;
using System.Collections.Generic;
using NTS = Newtonsoft.Json;

var model = new TestModel
{
    Id = 1,
    Title = "Test Title",
    Content = "This is a test content.",
    SeqNum = 100
};
var model2 = new TestModel
{
    Id = 2,
    Title = "Test Title-2",
    Content = "This is a test content.-2",
    SeqNum = 200
};
List<TestModel> models = new List<TestModel>();
models.Add(model);
models.Add(model2);
string jsonString = micJson.JsonSerializer.Serialize(models);
string newtonSoftJsonString = NTS.JsonConvert.SerializeObject(models);
Console.WriteLine($"Microsoft Json Library:{jsonString}");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"NewtonSoft Library:{newtonSoftJsonString}");
Console.ReadKey();

public class TestModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public int SeqNum { get; set; }
}
