using checkpoint8.Services;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StepsController
  {
    private readonly StepsService _ss;

    public StepsController(StepsService ss)
    {
      _ss = ss;
    }
  }
}