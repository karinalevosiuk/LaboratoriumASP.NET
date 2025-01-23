using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

    
    public class SuperpowersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperpowersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20;
            var superpowers = await _context.Superpowers
                .Include(sp => sp.HeroSuperpowers)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalSuperpowers = await _context.Superpowers.CountAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(totalSuperpowers / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(superpowers); 
        }

    }

    