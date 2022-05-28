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
  [Route("api/recipes/{recipeId}/[controller]")]
  public class StepsController : ControllerBase
  {
    private readonly StepsService _ss;
    public StepsController(StepsService ss)
    {
      _ss = ss;
    }
    [HttpGet("{id}")]
    public ActionResult<Step> Get(int id)
    {
      try
      {
        Step step = _ss.Get(id);
        return Ok(step);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> Create([FromBody] Step stepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        stepData.CreatorId = userInfo.Id;
        Step newStep = _ss.Create(stepData);
        return Ok(newStep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Step>> Edit(int id, [FromBody] Step stepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        stepData.CreatorId = userInfo.Id;
        Step step = _ss.Edit(stepData);
        return Ok(step);
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
        _ss.Delete(id, userInfo.Id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}