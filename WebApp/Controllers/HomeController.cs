using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

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
    public IActionResult Calculator(Operators? op, double? a, double? b)
    {
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby a lub b lub ich brak!";
            return View("CalculatorError");
        }
        
        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }
    
        ViewBag.A = a;
        ViewBag.B = b;

        double? result = 0.0;
        
        switch (op)
        {
            case Operators.Add:
                result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operators.Sub:
                result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operators.Mul:
                result = a * b;
                ViewBag.Operator = "*";
                break;
            case Operators.Div:
                if (b == 0)
                {
                    ViewBag.ErrorMessage = "Nie można dzielić przez zero!";
                    return View("CalculatorError");
                }
                result = a / b;
                ViewBag.Operator = "/";
                break;
        }
        
        ViewBag.Result = result;
        ViewBag.x = a;
        ViewBag.y = b;
    
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Age()
    {
       
        ViewBag.Age = null; 
        return View();
    }
    [HttpPost]
    public IActionResult Age(DateTime birthDate)
    {
        
        DateTime today = DateTime.Now;

        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;

        if (months < 0 || today.Month == birthDate.Month && today.Day < birthDate.Day)
        {
            years--;
            months += 12;
        }
        if (days < 0)
        {
           
            DateTime lastMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);
            months--; 
        }
        
       
        if (months < 0)
        {
            months += 12; 
        }
        
        
        ViewBag.Age = $"{years} lat, {months} miesięcy, {days} dni";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

