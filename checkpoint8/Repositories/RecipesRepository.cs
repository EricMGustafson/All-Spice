using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    internal List<Recipe> Get()
    {
      string sql = "SELECT r.*, a.* FROM recipes r JOIN accounts a ON r.creatorId = a.id;";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }).ToList();
    }

    internal Recipe Get(int id)
    {
      string sql = "SELECT r.*, a.* FROM recipes r JOIN accounts a on r.creatorId = a.id WHERE r.id = @id";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }, new { id }).FirstOrDefault();
    }

    internal Recipe Create(Recipe recipeData)
    {
      string sql = "INSERT INTO recipes (picture, title, subTitle, category, creatorId) VALUES (@Picture, @Title, @SubTitle, @Category, @CreatorId); SELECT LAST_INSERT_ID();";
      recipeData.Id = _db.ExecuteScalar<int>(sql, recipeData);
      return recipeData;
    }

    internal void Edit(Recipe original)
    {
      string sql = "UPDATE recipes SET category = @Category, picture = @Picture, subTitle = @SubTitle, title = @Title WHERE id = @Id";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}