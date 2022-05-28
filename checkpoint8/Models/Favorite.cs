using System;

namespace checkpoint8.Models
{
  public class Favorite
  {
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string AccountId { get; set; }
    public Account Creator { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}