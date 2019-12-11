using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Data.Entity;

namespace WebApplication6.Controllers
{
    public class LabasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LabasController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Labas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Labas.Include(l => l.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Labas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laba = await _context.Labas
                .Include(l => l.Student)
                .Include(l => l.Specification)
                    .ThenInclude(l => l.Author)
                .Include(l => l.Specification)
                    .ThenInclude(l => l.Requirments)
                        .ThenInclude(r=>r.TestCases)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (laba == null)
            {
                return NotFound();
            }

            return View(laba);
        }

        // GET: Labas/Create
        public async Task<IActionResult> Create(int? specificationId)
        {
            if(!specificationId.HasValue)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name");
            Laba laba = new Laba()
            {
                LabaStatus = Data.Entity.Enum.LabaStatus.SUBMITTED,
                SpecificationId = specificationId.Value,
                StudentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            return await Create(laba);
        }

        // POST: Labas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LabaStatus,StudentId, SpecificationId")] Laba laba)
        {
            laba.LabaStatus = Data.Entity.Enum.LabaStatus.SUBMITTED;
            if (ModelState.IsValid)
            {
                IList<TestCase> testCases = _context.TestCases.Where(a => 
                a.Requirment.SpecificationId == laba.SpecificationId).ToList();
                testCases.Select(r => new LabaCase()
                {
                    Laba = laba,
                    TestCase = r
                }).ToList().ForEach(l => laba.LabaCases.Add(l));

                _context.Add(laba);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit" , "LabasStudent", new { id = laba.Id});
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email", laba.StudentId);
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Id", laba.SpecificationId);
            return View(laba);
        }

        // GET: Labas/Edit/5
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
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email", laba.StudentId);
            return View(laba);
        }

        // POST: Labas/Edit/5
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
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Email", laba.StudentId);
            return View(laba);
        }

        // GET: Labas/Delete/5
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

        // POST: Labas/Delete/5
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
