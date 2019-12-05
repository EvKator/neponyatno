using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public SpecificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Specifications.Include(s => s.Author);
            return View(await applicationDbContext.ToListAsync());
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,AuthorId")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", specification.AuthorId);
            return View(specification);
        }

        // GET: Specifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specifications.FindAsync(id);
            if (specification == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", specification.AuthorId);
            return View(specification);
        }

        // POST: Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,AuthorId")] Specification specification)
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", specification.AuthorId);
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
