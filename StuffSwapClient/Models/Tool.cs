using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;


namespace StuffSwapClient.Models
{
    public class Tool{
        public int ToolId { get; set; }
        public string ToolName { get; set;  }
        public string ToolDescription { get; set; }
        public string ToolCategory { get; set; }
        public bool ToolStatus { get; set; }
        public int UserId { get; set; }
        public AppUser appUser { get; set; }
        public string ToolPhoto { get; set;}
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=false)]
        public DateTime ReturnDate { get; set;}
        

        public static List<Tool> GetTools(string model){
            Task<string> apiCallTask = ApiHelper.GetAll(model);
            string result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Tool> toolList = JsonConvert.DeserializeObject<List<Tool>>(jsonResponse.ToString());

            return toolList;
        }

        public static Tool GetDetails(int id, string model)
        {
            Task<string> apiCallTask = ApiHelper.Get(id, model);
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Tool tool = JsonConvert.DeserializeObject<Tool>(jsonResponse.ToString());

            return tool;
        }

        public static void Post(Tool tool, string model){
            string jsonTool = JsonConvert.SerializeObject(tool);
            ApiHelper.Post(jsonTool, model);
        }

        public static void Put(Tool tool, string model){
            string jsonTool = JsonConvert.SerializeObject(tool);
            ApiHelper.Put(tool.ToolId, jsonTool, model);
        }

        public static void Delete(int id, string model){
            ApiHelper.Delete(id, model);
        }
    }
}