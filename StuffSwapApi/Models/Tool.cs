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
    public string ToolStatus { get; set; }
    public string ReturnDate { get; set; }
    public string ToolPhoto { get; set; }
    public string UserId { get; set; }
  }
}