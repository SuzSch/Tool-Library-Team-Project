namespace StuffSwapClient.Models
{
    public class ToolUser
    { 
        public int ToolUserId { get; set; }
        public int UserId { get; set; }
        public AppUser appUser { get; set; }
        public int ToolId { get; set; }
        public Tool tool { get; set; }

    }
}
