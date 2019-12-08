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
using WebApplication6.Data.Entity.Enum;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    public class LabasStudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILabaCheckerService _labaCheckerService;

        public LabasStudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor, ILabaCheckerService checkerService)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _labaCheckerService = checkerService;
        }

        // GET: LabasStudent
        public async Task<IActionResult> Index()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var z = _context.Labas.Where(q => q.StudentId == userId).ToList();
            ;
            ;

            var applicationDbContext = _context.Labas
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
              .Include(l => l.LabaCases)
                  .ThenInclude(l => l.TestCase)
              .Include(l => l.LabaCases)
                  .ThenInclude(l => l.Requirment)
              .Include(l => l.Specification)
                  .ThenInclude(l => l.Requirments)
                      .ThenInclude(l => l.TestCases)
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
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Email");
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
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Email", laba.StudentId);
            return View(laba);
        }

        // GET: LabasStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laba = await _context.Labas
                .Include(a=>a.Specification)
                    .ThenInclude(a=>a.Requirments)
                        .ThenInclude(a=>a.TestCases)
                .Include(a => a.LabaCases)
                    .ThenInclude(a => a.Requirment)
                .Include(a => a.LabaCases)
                    .ThenInclude(a => a.TestCase)
                .Where(a=>a.Id == id)
                .FirstOrDefaultAsync();
            if (laba == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Email", laba.StudentId);
            ViewData["Status"] = new SelectList(new List<string>() { "SAVED", "READY_FOR_REVIEW" }, "Id", "Id", laba.LabaStatus);
            ViewData["RequirmentId"] = new SelectList(_context.Requirments, "Id", "Name", laba.Specification.Requirments);
            return View(laba);
        }

        // POST: LabasStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LabaStatus,StudentId, LabaCases, SpecificationId")] Laba laba)
        {
            if (id != laba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<LabaCase> labaCases = laba.LabaCases.Where(a => a.RequirmentId != null).ToList();
                    laba.LabaCases = labaCases;

                    laba.StudentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Update(laba);
                    _context.SaveChanges();
                    var labaUpdated = _context.Labas
                        .Include(l => l.Specification)
                            .ThenInclude(l=>l.Requirments)
                                .ThenInclude(l=>l.TestCases)
                        .Include(l => l.LabaCases)
                            .ThenInclude(l => l.Requirment)
                                .ThenInclude(l => l.TestCases)
                        .Include(l => l.LabaCases)
                            .ThenInclude(l => l.TestCase)
                        .Where(l => l.Id == laba.Id).FirstOrDefault();
                    if (labaUpdated.LabaStatus == LabaStatus.READY_FOR_REVIEW)
                    {
                        labaUpdated.Mark = _labaCheckerService.Check(labaUpdated);
                        labaUpdated.LabaStatus = LabaStatus.CHECKED;
                    }
                    _context.Update(labaUpdated);

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
            ViewData["StudentId"] = new SelectList(_context.ApplicationUser, "Id", "Email", laba.StudentId);
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
