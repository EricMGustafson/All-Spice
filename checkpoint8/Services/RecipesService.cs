using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> Get()
    {
      throw new NotImplementedException();
    }

    internal Recipe Get(int id)
    {
      throw new NotImplementedException();
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _repo.Create(recipeData);
    }

    internal Recipe Edit(Recipe recipeData)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}