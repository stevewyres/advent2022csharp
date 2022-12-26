using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Advent.Models;

namespace Advent.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Day1()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Day1Post()
    {
        var items = Request.Form["items"].ToString();

        var elfTotals = items
            .TrimEnd()
            .Split($"\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .Select(ids => new
            {
                summation = ids.Sum(a => int.Parse(a))
            })
            .OrderBy(x => x.summation)
            .TakeLast(3);

        var total = 0;

        foreach (var item in elfTotals)
        {
            total += item.summation;
        }

        return View("Day1Answer", total.ToString());
    }
}

