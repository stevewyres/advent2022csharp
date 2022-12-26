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
            // split the elfs into first dimension of array
            .Split($"\r\n\r\n")
            // now split with second dimension of array (items per elf)
            .Select(x => x.Split("\r\n"))
            // select and add up the totals for each elf
            .Select(ids => new
            {
                summation = ids.Sum(a => int.Parse(a))
            })
            // order so the largest at the end
            .OrderBy(x => x.summation)
            // then take the final three which will be added up to get the correct result
            .TakeLast(3);

        var total = 0;
        // add up the final three items
        foreach (var item in elfTotals)
        {
            total += item.summation;
        }

        return View("Day1Answer", total.ToString());
    }
}

