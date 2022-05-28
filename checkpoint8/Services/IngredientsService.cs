using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }
    internal List<Ingredient> GetIngredientsForRecipe(int id)
    {
      return _repo.GetIngredientsForRecipe(id);
    }
    internal Ingredient Get(int id)
    {
      Ingredient ingredient = _repo.Get(id);
      if (ingredient == null)
      {
        throw new Exception("Invalid Ingredient Id");
      }
      return ingredient;
    }
    internal Ingredient Create(Ingredient ingredientData)
    {
      return _repo.Create(ingredientData);
    }
    internal Ingredient Edit(Ingredient ingredientData)
    {
      Ingredient original = Get(ingredientData.Id);
      if (original.CreatorId != ingredientData.CreatorId)
      {
        throw new Exception("This is not your ingredient.");
      }
      original.Name = ingredientData.Name ?? original.Name;
      original.Quantity = ingredientData.Quantity ?? original.Quantity;
      _repo.Edit(original);
      return Get(original.Id);

    }
    internal void Delete(int id, string userId)
    {
      Ingredient ingredient = Get(id);
      if (ingredient.CreatorId != userId)
      {
        throw new Exception("This ingredient does not belong to you.");
      }
      _repo.Delete(id);
    }
  }
}