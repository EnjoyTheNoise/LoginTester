using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoginTester
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        private static async Task LoginSuccess()
        {
            var data = new
            {
                Email = "pedro123@XD.com",
                Password = "calkinieoznaczone"
            };

            var json = JsonConvert.SerializeObject(data);

            var result = await client.PostAsync("http://localhost:3155/api/user/login", new StringContent(json, Encoding.UTF8, "application/json"));

            var jsonResponse = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());

            Console.WriteLine("Successful login response:");
            Console.WriteLine(jsonResponse);
        }

        private static async Task LoginFailure()
        {
            var data = new
            {
                Email = "pedro123@XD.com",
                Password = "password123"
            };

            var json = JsonConvert.SerializeObject(data);

            var result = await client.PostAsync("http://localhost:3155/api/user/login", new StringContent(json, Encoding.UTF8, "application/json"));

            var jsonResponse = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());

            Console.WriteLine("Failed login response:");
            Console.WriteLine(jsonResponse);
        }

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await LoginSuccess();
            await LoginFailure();
            Console.ReadKey();
        }
    }
}
