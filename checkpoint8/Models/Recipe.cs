using System;

namespace checkpoint8.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    public string Picture { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }

  public class FavoritesViewModel : Recipe
  {
    public int FavoriteId { get; set; }
  }
}