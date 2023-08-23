using System.ComponentModel.DataAnnotations;

namespace StuffSwapApi.Models
{
  // ToolUser is the tool borrower, the tool owner is in the Tool model
  public class ToolUser
  {
    public int ToolUserId { get; set; }
    // below UserId is for the borrower
    public int AppUserId { get; set; }
    public int ToolId { get; set; }
    // User below is the borrower of the tool
    public AppUser User { get; set; }
    public Tool Tool { get; set; }

  }
}

