using diLifeTimes_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{

  private readonly ITypeScoped _typeScoped;

  private ITypeTransient _typeTransient;

  private ITypeSingleton _typeSingleton;

  public HelloWorldController(ITypeScoped typeScoped,
  ITypeTransient typeTransient,
  ITypeSingleton typeSingleton) {
    _typeScoped = typeScoped;
    _typeTransient = typeTransient;
    _typeSingleton = typeSingleton;
  }
  //
  // GET: /HelloWorld/
  // public string Index()
  public IActionResult Index([FromServices] ITypeScoped typeScoped,
  [FromServices] ITypeTransient typeTransient,
  [FromServices] ITypeSingleton typeSingleton)
  {
    _typeTransient.LogMethod();
    typeTransient.LogMethod();
    _typeScoped.LogMethod();
    typeScoped.LogMethod();
    _typeSingleton.LogMethod();
    typeSingleton.LogMethod();

    return View();
    // return "This is my default action...";
  }
  //
  // GET: /HelloWorld/Welcome/
  public string Welcome(string name,
  [FromServices] ITypeScoped typeScoped,
  [FromServices] ITypeTransient typeTransient,
  [FromServices] ITypeSingleton typeSingleton, int no = 1)
  {
    _typeTransient.LogMethod();
    typeTransient.LogMethod();
    _typeScoped.LogMethod();
    typeScoped.LogMethod();
    _typeSingleton.LogMethod();
    typeSingleton.LogMethod();

    return HtmlEncoder.Default.Encode($"Hello {name}, no of times is {no}");
    // return "This is the Welcome action method...";
  }
}
