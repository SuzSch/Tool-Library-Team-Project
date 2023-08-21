using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace StuffSwapClient.Models
{
    public class User
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
    

        public static List<User> GetUsers(string model){
            var apiCallTask = ApiHelper.GetAll(model);
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonResponse.ToString());
        }

        public static User GetDetails(int id, string model){
            var apiCallTask = ApiHelper.Get(id, model);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            User user = JsonConvert.DeserializeObject<User>(jsonResponse.ToString());
            return user;
        }

        public static void Post(User user, string model){
            string jsonUser = JsonConvert.SerializeObject(user);
            ApiHelper.Post(jsonUser, model);
        }

        public static void Put(User user, string model){
            string jsonUser = JsonConvert.SerializeObject(user);
            ApiHelper.Put(user.UserId, jsonUser, model);
        }

        public static void Delete(int id, string model){
            ApiHelper.Delete(id, model);
        }
    }
}