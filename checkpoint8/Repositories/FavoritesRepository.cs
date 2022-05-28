using System.Collections.Generic;
using System.Data;
using System.Linq;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Favorite Get(int id)
    {
      string sql = "SELECT f.*, a.* FROM favorites f JOIN accounts a ON f.accountId = a.id WHERE f.id = @id;";
      return _db.Query<Favorite, Account, Favorite>(sql, (favorite, account) =>
      {
        favorite.Creator = account;
        return favorite;
      }, new { id }).FirstOrDefault();
    }
    internal List<FavoritesViewModel> GetFavoritesByAccount(string id)
    {
      string sql = "SELECT a.*, a.id AS accountId, r.id AS recipeId, f.id FROM favorites f JOIN recipes r ON f.recipeId = r.id JOIN accounts a ON r.creatorId = a.id WHERE f.accountId = @id;";
      return _db.Query<Account, FavoritesViewModel, FavoritesViewModel>(sql, (account, favorite) =>
      {
        favorite.Creator = account;
        return favorite;
      }, new { id }).ToList();
    }
    internal Favorite Create(Favorite favoriteData)
    {
      string sql = "INSERT INTO favorites (recipeId, accountId) VALUES (@RecipeId, @AccountId); SELECT LAST_INSERT_ID();";
      favoriteData.Id = _db.ExecuteScalar<int>(sql, favoriteData);
      return favoriteData;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM favorites WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}