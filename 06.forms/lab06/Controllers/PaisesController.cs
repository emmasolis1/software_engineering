using lab05.Handlers;
using Microsoft.AspNetCore.Mvc;
using lab05.Models;

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

    [HttpGet]
    public ActionResult CrearPais() { 
      return View();
    }

    [HttpPost]
    public ActionResult CrearPais(PaisesModel pais)
    {
      ViewBag.ExitoAlCrear = false;
      try
      {
        if (ModelState.IsValid)
        {
          PaisesHandler paisesHandler = new PaisesHandler();
          ViewBag.ExitoAlCrear = paisesHandler.CrearPais(pais);

          if (ViewBag.ExitoAlCrear)
          {
            ViewBag.Message = "El pais " + pais.Nombre + " fue creado con exito.";
            ModelState.Clear();
          }
        }
        return View();
      }
      catch {
        ViewBag.Message = "Algo salió mal y no se pudo crear el pais";
        return View();
      }
    }

    [HttpGet]
    public ActionResult EditarPais(int identificador) {
      ActionResult vista;
      try
      {
        var paisesHandler = new PaisesHandler();
        var pais = paisesHandler.get_paises().Find(model => model.Id == identificador);
        if (pais == null)
        {
          vista = RedirectToAction("Index");
        }
        else
        {
          vista = View(pais);
        }
      }
      catch {
        vista = RedirectToAction("Index");
      }
    
      return vista;
    }

    [HttpPost]
    public ActionResult EditarPais(PaisesModel pais) {
      try
      {
        var paisesHandler = new PaisesHandler();
        paisesHandler.EditarPais(pais);
        return RedirectToAction("Index", "Paises");
      }
      catch {
        return View();
      }
    }


    [HttpGet]
    public ActionResult BorrarPais(int identificador) {
      try
      {
        var paisesHandler = new PaisesHandler();
        paisesHandler.BorrarPais(identificador);
        return RedirectToAction("Index", "Paises");
      }
      catch
      {
        return View();
      }
    }

  }
}
