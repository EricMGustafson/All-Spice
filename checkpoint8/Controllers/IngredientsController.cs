using System;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
  [ApiController]
  [Route("api/recipes/{ recipeId }/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ins;
    public IngredientsController(IngredientsService ins)
    {
      _ins = ins;
    }
    [HttpGet("{id}")]
    public ActionResult<Ingredient> Get(int id)
    {
      try
      {
        Ingredient ingredient = _ins.Get(id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ingredientData.CreatorId = userInfo.Id;
        Ingredient newIngredient = _ins.Create(ingredientData);
        return Ok(newIngredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Edit(int id, [FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ingredientData.CreatorId = userInfo.Id;
        Ingredient ingredient = _ins.Edit(ingredientData);
        return Ok(ingredient);
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
        _ins.Delete(id, userInfo.Id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}