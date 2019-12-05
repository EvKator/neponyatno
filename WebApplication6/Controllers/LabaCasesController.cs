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
    public class LabaCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabaCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabaCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LabaCases.Include(l => l.Laba).Include(l => l.Requirment).Include(l => l.TestCase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LabaCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labaCase = await _context.LabaCases
                .Include(l => l.Laba)
                .Include(l => l.Requirment)
                .Include(l => l.TestCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labaCase == null)
            {
                return NotFound();
            }

            return View(labaCase);
        }

        // GET: LabaCases/Create
        public IActionResult Create()
        {
            ViewData["LabaId"] = new SelectList(_context.Labas, "Id", "Id");
            ViewData["RequirmentId"] = new SelectList(_context.Requirments, "Id", "Name");
            ViewData["TestCaseId"] = new SelectList(_context.TestCases, "Id", "Name");
            return View();
        }

        // POST: LabaCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TestCaseId,RequirmentId,LabaId")] LabaCase labaCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labaCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabaId"] = new SelectList(_context.Labas, "Id", "Id", labaCase.LabaId);
            ViewData["RequirmentId"] = new SelectList(_context.Requirments, "Id", "Name", labaCase.RequirmentId);
            ViewData["TestCaseId"] = new SelectList(_context.TestCases, "Id", "Name", labaCase.TestCaseId);
            return View(labaCase);
        }

        // GET: LabaCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labaCase = await _context.LabaCases.FindAsync(id);
            if (labaCase == null)
            {
                return NotFound();
            }
            ViewData["LabaId"] = new SelectList(_context.Labas, "Id", "Id", labaCase.LabaId);
            ViewData["RequirmentId"] = new SelectList(_context.Requirments, "Id", "Name", labaCase.RequirmentId);
            ViewData["TestCaseId"] = new SelectList(_context.TestCases, "Id", "Name", labaCase.TestCaseId);
            return View(labaCase);
        }

        // POST: LabaCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TestCaseId,RequirmentId,LabaId")] LabaCase labaCase)
        {
            if (id != labaCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labaCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabaCaseExists(labaCase.Id))
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
            ViewData["LabaId"] = new SelectList(_context.Labas, "Id", "Id", labaCase.LabaId);
            ViewData["RequirmentId"] = new SelectList(_context.Requirments, "Id", "Name", labaCase.RequirmentId);
            ViewData["TestCaseId"] = new SelectList(_context.TestCases, "Id", "Name", labaCase.TestCaseId);
            return View(labaCase);
        }

        // GET: LabaCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labaCase = await _context.LabaCases
                .Include(l => l.Laba)
                .Include(l => l.Requirment)
                .Include(l => l.TestCase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labaCase == null)
            {
                return NotFound();
            }

            return View(labaCase);
        }

        // POST: LabaCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labaCase = await _context.LabaCases.FindAsync(id);
            _context.LabaCases.Remove(labaCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabaCaseExists(int id)
        {
            return _context.LabaCases.Any(e => e.Id == id);
        }
    }
}
