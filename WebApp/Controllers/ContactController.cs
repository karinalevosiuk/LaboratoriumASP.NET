﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContactController : Controller
{
   private readonly IContactService _contactService;

   public ContactController(IContactService contactService)
   {
       _contactService = contactService;
   }


   // Lista kontaktow
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }

    //Zwraca formularz dodania kontaktu
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    //Odebranie danych z formularza, zapisa kontaktu i powrot do listy kontaktow
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }     
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }

    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public IActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(Index));
    }
}