using System.Collections.Generic;
using System.Data;
using System.Linq;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Ingredient> GetIngredientsForRecipe(int id)
    {
      string sql = "SELECT a.*, i.* FROM ingredients i JOIN accounts a ON i.creatorId = a.id WHERE i.recipeId = @id;";
      return _db.Query<Account, Ingredient, Ingredient>(sql, (account, ingredient) =>
      {
        ingredient.Creator = account;
        return ingredient;
      }, new { id }).ToList();
    }
    internal Ingredient Get(int id)
    {
      string sql = "SELECT i.*, a.* FROM ingredients i JOIN accounts a ON i.creatorId = a.id WHERE i.id = @id;";
      return _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
      {
        ingredient.Creator = account;
        return ingredient;
      }, new { id }).FirstOrDefault();
    }
    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = "INSERT INTO ingredients (name, quantity, creatorId, recipeId) VALUES (@Name, @Quantity, @CreatorId, @RecipeId); SELECT LAST_INSERT_ID();";
      ingredientData.Id = _db.ExecuteScalar<int>(sql, ingredientData);
      return ingredientData;
    }
    internal void Edit(Ingredient original)
    {
      string sql = "UPDATE ingredients SET name = @Name, quantity = @Quantity WHERE id = @Id;";
      _db.Execute(sql, original);
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM ingredients WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}