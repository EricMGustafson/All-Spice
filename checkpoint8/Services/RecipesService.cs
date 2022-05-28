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
      return _repo.Get();
    }
    internal Recipe Get(int id)
    {
      Recipe recipe = _repo.Get(id);
      if (recipe == null)
      {
        throw new Exception("Invalid Recipe Id");
      }
      return recipe;
    }
    internal Recipe Create(Recipe recipeData)
    {
      return _repo.Create(recipeData);
    }
    internal Recipe Edit(Recipe recipeData)
    {
      Recipe original = Get(recipeData.Id);
      if (original.CreatorId != recipeData.CreatorId)
      {
        throw new Exception("This is not your recipe.");
      }
      original.Category = recipeData.Category ?? original.Category;
      original.Picture = recipeData.Picture ?? original.Picture;
      original.SubTitle = recipeData.SubTitle ?? original.SubTitle;
      original.Title = recipeData.Title ?? original.Title;
      _repo.Edit(original);
      return Get(original.Id);
    }
    internal void Delete(int id, string userId)
    {
      Recipe recipe = Get(id);
      if (recipe.CreatorId != userId)
      {
        throw new Exception("This recipe does not belong to you.");
      }
      _repo.Delete(id);
    }
  }
}