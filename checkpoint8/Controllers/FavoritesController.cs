using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
  [ApiController]
  [Route("account/[controller]")]
  public class FavoritesController : ControllerBase
  {
    private readonly FavoritesService _fs;

    public FavoritesController(FavoritesService fs)
    {
      _fs = fs;
    }
    [HttpGet("{id}")]
    public ActionResult<Favorite> Get(int id)
    {
      try
      {
        Favorite favorite = _fs.Get(id);
        return Ok(favorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    public async Task<ActionResult<List<FavoritesViewModel>>> GetFavoritesByAccount()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<FavoritesViewModel> favorites = _fs.GetFavoritesByAccount(userInfo.Id);
        return Ok(favorites);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        favoriteData.AccountId = userInfo.Id;
        Favorite favorite = _fs.Create(favoriteData);
        favorite.Creator = userInfo;
        return Ok(favorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _fs.Delete(id, userInfo.Id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}