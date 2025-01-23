using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Form()
    {
        return View();
    }
 
    
    
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            ViewBag.ErrorMessage = "Niepoprawne dane wejściowe!";
            return View("CustomError");
        }

        return View(model);
    }

    
   
    
    
    public enum Operator
    {
        Add,Sub,Div,Mul,
    }
}