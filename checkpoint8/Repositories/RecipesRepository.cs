using System.Data;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe Create(Recipe recipeData)
    {
      string sql = "INSERT INTO recipes (picture, title, subTitle, category, creatorId) VALUES (@Picture, @Title, @SubTitle, @Category, @CreatorId); SELECT LAST_INSERT_ID();";
      recipeData.Id = _db.ExecuteScalar<int>(sql, recipeData);
      return recipeData;
    }
  }
}