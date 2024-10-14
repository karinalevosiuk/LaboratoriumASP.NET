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
    
    //Zadanie domowe
    //Napisz metode Age, ktora przyjmuje parametre z data urodzin i wyswietla wiek w latach, miesiacach i dniach

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        //var op =Request.Query["op"];
        //var x = double.Parse(Request.Query["x"]);
        //var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y lub ich brak!";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }
        double? result = 0.0;
        switch (op)
        {
            case Operator.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operator.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                result = x / y;
                ViewBag.Operator = ":";
                break;
                
            
        }
        
        ViewBag.Result = result;
        ViewBag.x = x;
        ViewBag.y = y;
        
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

public enum Operator
{
    Add,Sub,Mul,Div
}