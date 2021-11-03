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
    public class MonedasConvertidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonedasConvertidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonedaConvertidas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonedaConvertida
              .Include(p => p.Moneda)
              .Where(p => p.Moneda.MonedaId == p.MonedaId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonedaConvertidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monedaConvertida = await _context.MonedaConvertida
                .Include(m => m.Conversion)
                .Include(m => m.Moneda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monedaConvertida == null)
            {
                return NotFound();
            }

            return View(monedaConvertida);
        }

        // GET: MonedaConvertidas/Create
        public IActionResult Create()
        {
            ViewData["ConversionId"] = new SelectList(_context.Conversion, "ConversionId", "ConversionId");
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "MonedaId", "Nombre");
            return View();
        }

        // POST: MonedaConvertidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MonedaId,Cantidad,ConversionId")] MonedaConvertida monedaConvertida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monedaConvertida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConversionId"] = new SelectList(_context.Conversion, "ConversionId", "ConversionId", monedaConvertida.ConversionId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "MonedaId", "Nombre", monedaConvertida.MonedaId);
            return View(monedaConvertida);
        }

        // GET: MonedaConvertidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monedaConvertida = await _context.MonedaConvertida.FindAsync(id);
            if (monedaConvertida == null)
            {
                return NotFound();
            }
            ViewData["ConversionId"] = new SelectList(_context.Conversion, "ConversionId", "ConversionId", monedaConvertida.ConversionId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "MonedaId", "Nombre", monedaConvertida.MonedaId);
            return View(monedaConvertida);
        }

        // POST: MonedaConvertidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MonedaId,Cantidad,ConversionId")] MonedaConvertida monedaConvertida)
        {
            if (id != monedaConvertida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monedaConvertida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonedaConvertidaExists(monedaConvertida.Id))
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
            ViewData["ConversionId"] = new SelectList(_context.Conversion, "ConversionId", "ConversionId", monedaConvertida.ConversionId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "MonedaId", "Nombre", monedaConvertida.MonedaId);
            return View(monedaConvertida);
        }

        // GET: MonedaConvertidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monedaConvertida = await _context.MonedaConvertida
                .Include(m => m.Conversion)
                .Include(m => m.Moneda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monedaConvertida == null)
            {
                return NotFound();
            }

            return View(monedaConvertida);
        }

        // POST: MonedaConvertidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monedaConvertida = await _context.MonedaConvertida.FindAsync(id);
            _context.MonedaConvertida.Remove(monedaConvertida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonedaConvertidaExists(int id)
        {
            return _context.MonedaConvertida.Any(e => e.Id == id);
        }
    }
}
