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
            RestRequest request = new RestRequest($"api/{model}/{id}", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
        }

        public static async void Post(string newTool, string model){
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/{model}", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newTool);
            await client.PostAsync(request);
        }

        public static async void Put(int id, string selectedTool, string model){
            RestClient client = new RestClient("https://localhost:5001/");
            RestRequest request = new RestRequest($"api/{model}/{id}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(selectedTool);
            await client.PutAsync(request);
        }

        public static async void Delete(int id, string model){
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/{model}/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            await client.DeleteAsync(request);
        }

         public static async Task<string> LogIn(string jsonUser)
        {
            RestClient client = new RestClient("http://localhost:5000");
            RestRequest request = new RestRequest($"getToken", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonUser);
            RestResponse response = await client.PostAsync(request);
            return response.Content;
        }
    }
}   