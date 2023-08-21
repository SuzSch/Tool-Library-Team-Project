namespace StuffSwapClient.Models
{
    public class ToolUser
    { 
        public int ToolUserId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ToolId { get; set; }
        public Tool tool { get; set; }

    }
}
