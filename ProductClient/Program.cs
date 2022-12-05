// See https://aka.ms/new-console-template for more information
//using System.ComponentModel.DataAnnotations;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using X00180930_EAD_CA2.Models;

//Console.WriteLine("Hello, World!");

//namespace ProductClient
//{
//    class Client
//    {
//        // async call
//        static async Task DoWork()
//        {
//            try
//            {
//                //1)  create an instance of HttpClient
//                using (HttpClient client = new HttpClient())
//                {
//                    //2)  init the base address
//                    client.BaseAddress = new Uri("http://localhost:5032/");                             // base URL for API Controller i.e. RESTFul service

//                    // 3) Set the media types this client will accept (in this case, for a webservice,  JSON) so we add an Accept header for JSON
//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                    // 1
//                    // Get all products
//                    // GET ../weather/all
//                    HttpResponseMessage response = await client.GetAsync("product/all");
//                    if (response.IsSuccessStatusCode)                                                   // 200.299
//                    {
//                        // read result 
//                        var repo = await response.Content.ReadAsAsync<IEnumerable<Product>>();
//                        foreach (var p in repo)
//                        {
//                            Console.WriteLine(p.ProductName + " " + p.ProductPrice);
//                        }
//                    }
//                }
//                    catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            // kick off
//            static void Main()
//                    {
//                        DoWork().Wait();
//                    }
//                }
//            }
//}
//Got this to work
// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync("https://localhost:7032/api/Product"); // or"https://localhost:7032/api/MockDB"  https://localhost:7032
                                                                                       //https://localhost:7032/api/MockDB
    Console.Write(json);

    await using Stream stream = await client.GetStreamAsync("https://localhost:7032/api/Product"); //https://localhost:7032/api/MockDB
    var repositories =
        await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(stream);

    foreach (var item in repositories)
    {
        Console.WriteLine($" {item.ProductID}, {item.ProductPrice}");
    }
}

public class Product
{
    
    public int ProductID { get; set; }
   
    public string ProductName { get; set; } = "";
   
    public double ProductPrice { get; set; }
   
    public int Rating { get; set; }
    public Category ProductCategory { get; set; }
    public Size ProductSize { get; set; }


}