using System.ComponentModel.DataAnnotations;

namespace StuffSwapApi.Models
{
  public class Tool
  {
    public int ToolId { get; set; }

    [Required]
    public string ToolName { get; set; }
    public string ToolDescription { get; set; }
    public string ToolCategory { get; set; }
    public string ToolStatus { get; set; } = "Available";
    public string ReturnDate { get; set; }
    public string ToolPhoto { get; set; }
    // the UserId below is the owner
    public int AppUserId { get; set; }

    //todo should there be a join
  }
}