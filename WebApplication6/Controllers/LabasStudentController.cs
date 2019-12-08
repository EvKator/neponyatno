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
    public class LabasStudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LabasStudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: LabasStudent
        public async Task<IActionResult> Index()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationDbContext = _context.Labas
                .Where(a=>a.LabaStatus == Data.Entity.Enum.LabaStatus.SUBMITTED)
                .Where(a=>a.StudentId == userId)
                .Include(l => l.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LabasStudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laba = await _context.Labas
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laba == null)
            {
                return NotFound();
            }

            return View(laba);
        }

        // GET: LabasStudent/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: LabasStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LabaStatus,StudentId")] Laba laba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Id", laba.StudentId);
            return View(laba);
        }

        // GET: LabasStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laba = await _context.Labas.FindAsync(id);
            if (laba == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Id", laba.StudentId);
            return View(laba);
        }

        // POST: LabasStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LabaStatus,StudentId")] Laba laba)
        {
            if (id != laba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabaExists(laba.Id))
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
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Id", laba.StudentId);
            return View(laba);
        }

        // GET: LabasStudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laba = await _context.Labas
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laba == null)
            {
                return NotFound();
            }

            return View(laba);
        }

        // POST: LabasStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laba = await _context.Labas.FindAsync(id);
            _context.Labas.Remove(laba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabaExists(int id)
        {
            return _context.Labas.Any(e => e.Id == id);
        }
    }
}
