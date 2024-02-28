using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using diLifeTimes_.Models;

namespace diLifeTimes_.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private ITypeSingleton TypeSingleton_ { get; set; }

    private ITypeScoped TypeScoped_ { get; set; }

    private ITypeTransient TypeTransient_ { get; set; }

    public HomeController(ILogger<HomeController> logger, ITypeSingleton typeSingleton, ITypeScoped typeScoped, ITypeTransient typeTransient)
    {
        _logger = logger;
        TypeSingleton_ = typeSingleton;
        TypeScoped_ = typeScoped;
        TypeTransient_ = typeTransient;
    }

    public IActionResult Index()
    {
        /* TypeSingleton_.LogMethod();
        TypeTransient_.LogMethod();
        TypeSingleton_.LogMethod();
        TypeTransient_.LogMethod(); */
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
