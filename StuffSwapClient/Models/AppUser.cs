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
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
            ApiHelper.Put(appUser.UserId, jsonUser, model);
        }

        public static void Delete(int id, string model){
            ApiHelper.Delete(id, model);
        }
    }
}