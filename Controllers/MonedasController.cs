using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albamon.Data;
using Albamon.Models;
using Albamon.Models.NFTViewModels;


namespace Albamon.Controllers
{
    public class MonedasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonedasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monedas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moneda.ToListAsync());
        }

        // GET: Monedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda
                .FirstOrDefaultAsync(m => m.MonedaId == id);
            if (moneda == null)
            {
                return NotFound();
            }

            return View(moneda);
        }

        // GET: Monedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonedaId,Nombre,CantidadCompra,CantidadVenta")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneda);
        }

        // GET: Monedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda.FindAsync(id);
            if (moneda == null)
            {
                return NotFound();
            }
            return View(moneda);
        }

        // POST: Monedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonedaId,Nombre,CantidadCompra,CantidadVenta")] Moneda moneda)
        {
            if (id != moneda.MonedaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonedaExists(moneda.MonedaId))
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
            return View(moneda);
        }

        // GET: Monedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneda = await _context.Moneda
                .FirstOrDefaultAsync(m => m.MonedaId == id);
            if (moneda == null)
            {
                return NotFound();
            }

            return View(moneda);
        }

        // POST: Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneda = await _context.Moneda.FindAsync(id);
            _context.Moneda.Remove(moneda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonedaExists(int id)
        {
            return _context.Moneda.Any(e => e.MonedaId == id);
        }

        //Get: Get Monedas FOR selection
        [HttpGet]
        public IActionResult SelectMonedasForConvertir(String TypeMonedaSelected, double Price)
        {
            SelectMonedasForConvertirViewModel selectcoin = new SelectMonedasForConvertirViewModel();
            selectcoin.Typemoneda = new SelectList(_context.Moneda.Select(g => g.Nombre).ToList());
            selectcoin.monedas = _context.Moneda
                .Include(m => m.MonedasConvertidas) //join table Nft and table typenft
                .Where(m => ((m.CantidadCompra > 200) && (m.CantidadVenta > 200) || Price == 0)
                && (m.Nombre.Contains(TypeMonedaSelected) || TypeMonedaSelected == null));

            //selectcoin.monedas = selectcoin.monedas.ToList();
            return View(selectcoin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectMonedasForConvertir(SelectedMonedasForConvertirViewModel selectedMoneda)
        {
            if (selectedMoneda.IdsToAdd != null)
            {

                return RedirectToAction("Create", "Purchases", selectedMoneda);
            }
            //a message error will be shown to the customer in case no movies are selected
            ModelState.AddModelError(string.Empty, "You must select at least one coin");

            //the View SelectMonedasForConvertir will be shown again
            return SelectMonedasForConvertir(selectedMoneda.TypeMonedaSelected, selectedMoneda.Price);
        }


    }
}

