using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace StuffSwapClient.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        public string UserPhoto { get; set;}
        public string Address { get; set;}
        //public int ToolId {get; set;}
        public List<Tool> ownedTools {get; set;}
    

        public static List<AppUser> GetUsers(string model){
            var apiCallTask = ApiHelper.GetAll(model);
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<AppUser> appUserList = JsonConvert.DeserializeObject<List<AppUser>>(jsonResponse.ToString());
            return appUserList;
        }

        public static AppUser GetDetails(int id, string model){
            var apiCallTask = ApiHelper.Get(id, model);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            AppUser appUser = JsonConvert.DeserializeObject<AppUser>(jsonResponse.ToString());
            return appUser;
        }

        public static void Post(AppUser appUser, string model){
            string jsonUser = JsonConvert.SerializeObject(appUser);
            ApiHelper.Post(jsonUser, model);
        }

        public static void Put(AppUser appUser, string model){
            string jsonUser = JsonConvert.SerializeObject(appUser);
            ApiHelper.Put(appUser.AppUserId, jsonUser, model);
        }

        public static void Delete(int id, string model){
            ApiHelper.Delete(id, model);
        }

        // public static async Task<string> LogIn(AppUser appUser)
        // {
        //     string jsonUser = JsonConvert.SerializeObject(appUser);
        //     RestClient client = new RestClient("http://localhost:5000");
        //     RestRequest request = new RestRequest($"getToken", Method.Post);
        //     request.AddHeader("Content-Type", "application/json");
        //     request.AddJsonBody(jsonUser);
        //     RestResponse response = await client.PostAsync(request);
            //    return response.Content;
        // } 
        
        // public static async Task<string> Get(int id, string model)
        // {
        //     RestClient client = new RestClient("http://localhost:5000");
        //     RestRequest request = new RestRequest($"api/{model}/{id}", Method.Get);
        //     RestResponse response = await client.GetAsync(request);
        //     return response.Content;
        // }



    }
}