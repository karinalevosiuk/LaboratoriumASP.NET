using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Superheroes;
using System.Linq;
using System.Threading.Tasks;
using System;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class HeroController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserAuthService _userAuthService;
        
        public HeroController(ApplicationDbContext context, UserAuthService userAuthService)
        {
            _context = context;
            _userAuthService = userAuthService;
        }
        
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20; 
            var heroesQuery = _context.Heroes
                .Include(h => h.HeroSuperpowers)
                .ThenInclude(hs => hs.Superpower); 

            var totalHeroes = await heroesQuery.CountAsync();

            var heroes = await heroesQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(totalHeroes / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(heroes); 
        }
        
        public IActionResult Create()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account"); 
            }
            
            var superpowers = _context.Superpowers.ToList(); 
            
            ViewBag.Superpowers = superpowers;
            
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hero hero, List<int> selectedSuperpowers)
        {
            var username = User.Identity?.Name;  

            if (!_userAuthService.IsAuthenticated(username))
            {
                return RedirectToAction("Login", "Account"); 
            }

            if (ModelState.IsValid)
            {
                _context.Heroes.Add(hero);
                
                foreach (var superpowerId in selectedSuperpowers)
                {
                    var heroSuperpower = new HeroSuperpower
                    {
                        HeroId = hero.Id,
                        SuperpowerId = superpowerId
                    };
                    _context.Add(heroSuperpower);
                }

                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); 
            }
            
            ViewBag.Superpowers = _context.Superpowers.ToList();
            return View(hero); 
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var hero = await _context.Heroes
                .Include(h => h.HeroSuperpowers)
                .ThenInclude(hp => hp.Superpower) 
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hero == null)
            {
                return NotFound(); 
            }

            return View(hero); 
        }
    }
}