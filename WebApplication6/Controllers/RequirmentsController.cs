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
    public class RequirmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequirmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requirments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requirments.Include(r => r.Specification);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requirments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirment = await _context.Requirments
                .Include(r => r.Specification)
                .Include(r=>r.TestCases)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirment == null)
            {
                return NotFound();
            }

            return View(requirment);
        }

        // GET: Requirments/Create
        public IActionResult Create(int? specificationId)
        {
            if(!specificationId.HasValue)
            {
                return NotFound();
            }
            ViewBag.SpecificationId = specificationId.Value;
            return View();
        }

        // POST: Requirments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Name,Description,SpecificationId")] Requirment requirment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requirment);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Edit", "Specifications", new { id = requirment.SpecificationId });
                return new OkResult();
            }
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", requirment.SpecificationId);
            return View(requirment);
        }

        // GET: Requirments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirment = await _context.Requirments.FindAsync(id);
            if (requirment == null)
            {
                return NotFound();
            }
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", requirment.SpecificationId);
            return View(requirment);
        }

        // POST: Requirments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SpecificationId")] Requirment requirment)
        {
            if (id != requirment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requirment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirmentExists(requirment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "Specifications", new { id = requirment.SpecificationId });
            }
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", requirment.SpecificationId);
            return View(requirment);
        }

        // GET: Requirments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirment = await _context.Requirments
                .Include(r => r.Specification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirment == null)
            {
                return NotFound();
            }

            return View(requirment);
        }

        // POST: Requirments/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requirment = await _context.Requirments.FindAsync(id);
            _context.Requirments.Remove(requirment);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        private bool RequirmentExists(int id)
        {
            return _context.Requirments.Any(e => e.Id == id);
        }
    }
}
