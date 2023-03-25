using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.MVC.Data;

namespace SchoolManagementApp.MVC.Controllers
{
    public class LecturersController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public LecturersController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Lecturers
        public async Task<IActionResult> Index()
        {
              return _context.Lecturers != null ? 
                          View(await _context.Lecturers.ToListAsync()) :
                          Problem("Entity set 'SchoolManagementDbContext.Lecturers'  is null.");
        }

        // GET: Lecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // GET: Lecturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers.FindAsync(id);
            if (lecturers == null)
            {
                return NotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Lecturers lecturers)
        {
            if (id != lecturers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturersExists(lecturers.Id))
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
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lecturers == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.Lecturers'  is null.");
            }
            var lecturers = await _context.Lecturers.FindAsync(id);
            if (lecturers != null)
            {
                _context.Lecturers.Remove(lecturers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturersExists(int id)
        {
          return (_context.Lecturers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
