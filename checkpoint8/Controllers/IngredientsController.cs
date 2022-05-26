using checkpoint8.Services;

namespace checkpoint8.Controllers
{
  public class IngredientsController
  {
    private readonly IngredientsService _ins;

    public IngredientsController(IngredientsService ins)
    {
      _ins = ins;
    }
  }
}