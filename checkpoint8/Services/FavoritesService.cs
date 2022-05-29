using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Repositories;

namespace checkpoint8.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _repo;
    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }
    internal Favorite Get(int id)
    {
      Favorite favorite = _repo.Get(id);
      if (favorite == null)
      {
        throw new Exception("Invalid Favorite Id.");
      }
      return favorite;
    }
    internal List<FavoritesViewModel> GetFavoritesByAccount(string id)
    {
      return _repo.GetFavoritesByAccount(id);
    }
    internal Favorite Create(Favorite favoriteData)
    {
      List<FavoritesViewModel> favorites = GetFavoritesByAccount(favoriteData.AccountId);
      for (int i = 0; i < favorites.Count; i++)
      {
        if (favoriteData.RecipeId == favorites[i].Id)
        {
          throw new Exception("You have already favorited this recipe.");
        }
      }
      return _repo.Create(favoriteData);
    }
    internal void Delete(int id, string userId)
    {
      Favorite favorite = Get(id);
      if (favorite.AccountId != userId)
      {
        throw new Exception("This is the incorrect id.");
      }
      _repo.Delete(id);
    }
  }
}