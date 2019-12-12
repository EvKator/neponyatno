using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Data.Entity;

namespace WebApplication6.Controllers
{
    public class SpecificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly UserManager<ApplicationUser> _userManager;


        public SpecificationsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        // GET: Specifications
        public async Task<IActionResult> Index()
        {
            ;
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            //var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //string role = (await _userManager.GetRolesAsync(user))[0];
            //bool q = User.IsInRole(role);
            //ViewBag.Role = role;
            //UserManager.IsInRole(User.Identity.GetUserId(), "admin")
            ;
            ;
            ;
            ;
            ;
            ;
            ;
            ;
            if (User.IsInRole("Student"))
            {
                var doneLabs = _context.Labas.Where(m => (m.StudentId == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value && (m.LabaStatus == Data.Entity.Enum.LabaStatus.SAVED || m.LabaStatus == Data.Entity.Enum.LabaStatus.CHECKED))).Select(m => m.SpecificationId);// && m.LabaStatus == Data.Entity.Enum.LabaStatus.CHECKED && m.LabaStatus == Data.Entity.Enum.LabaStatus.SAVED).Select(m => m.SpecificationId);
                var applicationDbContextStudent = _context.Specifications.Include(s => s.Author).Where(s => !doneLabs.Contains(s.Id));
                return View(await applicationDbContextStudent.ToListAsync());
            }
            else
            {
                var applicationDbContextAdmin = _context.Specifications.Include(s => s.Author);
                return View(await applicationDbContextAdmin.ToListAsync());
            }
            ;
            ;
            ;
            ;
            ;
            ;
            ;
        }

        // GET: Specifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specifications
                .Include(s => s.Author)
                .Include(s=>s.Requirments)
                    .ThenInclude(s=>s.TestCases)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        // GET: Specifications/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,QuestionsPerStudent")] Specification specification)
        {

            if (ModelState.IsValid)
            {
                specification.AuthorId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(specification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", specification.AuthorId);
            return View(specification);
        }

        // GET: Specifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specifications.Include(m => m.Requirments).ThenInclude(y => y.TestCases).FirstAsync(m => m.Id == id);
            if (specification == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", specification.AuthorId);
            return View(specification);
        }

        public async Task<IActionResult> RenderRequirments(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specifications.Include(m => m.Requirments).ThenInclude(y => y.TestCases).FirstAsync(m => m.Id == id);
            specification.Requirments = specification.Requirments.OrderByDescending(m => m.Id).ToList();
            if (specification == null)
            {
                return NotFound();
            }
            return PartialView("Requirments", specification);
        }

        // POST: Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,AuthorId,QuestionsPerStudent ")] Specification specification)
        {
            if (id != specification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificationExists(specification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", specification.AuthorId);
            return View(specification);
        }

        // GET: Specifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specifications
                .Include(s => s.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        // POST: Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specification = await _context.Specifications.FindAsync(id);
            _context.Specifications.Remove(specification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecificationExists(int id)
        {
            return _context.Specifications.Any(e => e.Id == id);
        }
    }
}
