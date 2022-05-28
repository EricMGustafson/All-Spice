using System;
using System.Collections.Generic;
using System.Data;
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
      throw new NotImplementedException();
    }
    internal List<Favorite> Get()
    {
      throw new NotImplementedException();
    }
    internal Favorite Create(Favorite favoriteData)
    {
      string sql = "INSERT INTO favorites (recipeId, accountId) VALUES (@RecipeId, @AccountId); SELECT LAST_INSERT_ID();";
      favoriteData.Id = _db.ExecuteScalar<int>(sql, favoriteData);
      return favoriteData;
    }
    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}