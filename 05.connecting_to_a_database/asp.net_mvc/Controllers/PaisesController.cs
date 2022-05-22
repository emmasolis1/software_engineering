using lab05.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace lab05.Controllers
{
  public class PaisesController : Controller
  {
    public IActionResult Index()
    {
      PaisesHandler handler = new PaisesHandler();
      var paises = handler.get_paises();
      ViewBag.MainTittle = "Lista de Paises";

      return View(paises);
    }
  }
}
