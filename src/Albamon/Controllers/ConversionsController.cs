using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albamon.Data;
using Albamon.Models;

namespace Albamon.Controllers
{
    public class ConversionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConversionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conversions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conversion.Include(c => c.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Conversions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversion = await _context.Conversion
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ConversionId == id);
            if (conversion == null)
            {
                return NotFound();
            }

            return View(conversion);
        }

        // GET: Conversions/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: Conversions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConversionId,FechaConversion,ClienteId")] Conversion conversion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conversion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", conversion.ClienteId);
            return View(conversion);
        }

        // GET: Conversions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversion = await _context.Conversion.FindAsync(id);
            if (conversion == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", conversion.ClienteId);
            return View(conversion);
        }

        // POST: Conversions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConversionId,FechaConversion,ClienteId")] Conversion conversion)
        {
            if (id != conversion.ConversionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conversion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConversionExists(conversion.ConversionId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", conversion.ClienteId);
            return View(conversion);
        }

        // GET: Conversions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversion = await _context.Conversion
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ConversionId == id);
            if (conversion == null)
            {
                return NotFound();
            }

            return View(conversion);
        }

        // POST: Conversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conversion = await _context.Conversion.FindAsync(id);
            _context.Conversion.Remove(conversion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConversionExists(int id)
        {
            return _context.Conversion.Any(e => e.ConversionId == id);
        }
    }
}
