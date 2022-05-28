using System.Collections.Generic;
using System.Data;
using System.Linq;
using checkpoint8.Models;
using Dapper;

namespace checkpoint8.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;
    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Step> GetStepsForRecipe(int id)
    {
      string sql = "SELECT a.*, s.* FROM steps s JOIN accounts a ON s.creatorId = a.id WHERE s.recipeId = @id;";
      return _db.Query<Account, Step, Step>(sql, (account, step) =>
      {
        step.Creator = account;
        return step;
      }, new { id }).ToList();
    }
    internal Step Get(int id)
    {
      string sql = "SELECT s.*, a.* FROM steps s JOIN accounts a ON s.creatorId = a.id WHERE s.id = @id;";
      return _db.Query<Step, Account, Step>(sql, (step, account) =>
      {
        step.Creator = account;
        return step;
      }, new { id }).FirstOrDefault();
    }
    internal Step Create(Step stepData)
    {
      string sql = "INSERT INTO steps (body, position, creatorId, recipeId) VALUES (@Body, @Position, @CreatorId, @RecipeId); SELECT LAST_INSERT_ID();";
      stepData.Id = _db.ExecuteScalar<int>(sql, stepData);
      return stepData;
    }
    internal void Edit(Step original)
    {
      string sql = "UPDATE steps SET body = @Body, position = @Position WHERE id = @id;";
      _db.Execute(sql, original);
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM steps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}