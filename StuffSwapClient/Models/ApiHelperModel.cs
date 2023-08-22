using System.Threading.Tasks;
using RestSharp;

namespace StuffSwapClient.Models{
    public class ApiHelper
    {
        public static async Task<string> GetAll(string model)
        {
        RestClient client = new RestClient("http://localhost:5000");
        RestRequest request = new RestRequest($"api/{model}", Method.Get);
        RestResponse response = await client.GetAsync(request);
        return response.Content;
        }

        public static async Task<string> Get(int id, string model)
        {
            RestClient client = new RestClient("http://localhost:5000");
            REstRequest request = new RestRequest($"api/{model}/{id}", Method.Get);
            RestRespone response = await client.GetAsync(request);
            return response.Content;
        }

        public static async void Post(string newTool, string model){
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/{model}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newTool);
            await client.PostAsync(request);
        }

        public static async void Put(int id, string newTool, string model){
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/{model}/{id}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newTool);
            await client.PutAsync(request);
        }

        public static async void Delete(int id, string model){
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/{model}/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            await client.DeleteAsync(request);
        }
    }
}   