using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTN_BTMVC.Data;
using NTN_BTMVC.Models;

namespace NTN_BTMVC.Controllers
{
    public class ClassSectionsController : Controller
    {
        private readonly AppDbContext _context;

        public ClassSectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClassSections
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ClassSections.Include(c => c.Course).Include(c => c.Teacher);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ClassSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSection = await _context.ClassSections
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassSectionId == id);
            if (classSection == null)
            {
                return NotFound();
            }

            return View(classSection);
        }

        // GET: ClassSections/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: ClassSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassSectionId,ClassName,CourseId,TeacherId")] ClassSection classSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classSection.TeacherId);
            return View(classSection);
        }

        // GET: ClassSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSection = await _context.ClassSections.FindAsync(id);
            if (classSection == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classSection.TeacherId);
            return View(classSection);
        }

        // POST: ClassSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassSectionId,ClassName,CourseId,TeacherId")] ClassSection classSection)
        {
            if (id != classSection.ClassSectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassSectionExists(classSection.ClassSectionId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classSection.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", classSection.TeacherId);
            return View(classSection);
        }

        // GET: ClassSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSection = await _context.ClassSections
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassSectionId == id);
            if (classSection == null)
            {
                return NotFound();
            }

            return View(classSection);
        }

        // POST: ClassSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classSection = await _context.ClassSections.FindAsync(id);
            if (classSection != null)
            {
                _context.ClassSections.Remove(classSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassSectionExists(int id)
        {
            return _context.ClassSections.Any(e => e.ClassSectionId == id);
        }
    }
}
