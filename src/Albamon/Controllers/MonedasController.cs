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
        //Get: Get NFTS FOR selection
        [HttpGet]
        public IActionResult SelectMonedasForPurchase(string MonedasSelected, double Price)
        {
            SelectMonedasforConvertirViewModel selectMonedas = new SelectMonedasforConvertirViewModel();
            selectMonedas. = new SelectList(_context.TypeNFT.Select(g => g.Name).ToList());
            selectMonedas.NFTS = _context.NFT
                .Include(m => m.TypeNFT) //join table Nft and table typenft
                .Where(m => (m.Price < Price  Price == 0)
                && (m.TypeNFT.Name.Contains(TypeNFTSelected)  TypeNFTSelected == null));

            selectnfts.NFTS = selectnfts.NFTS.ToList();
            return View(selectnfts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectNftsForPurchase(SelectMonedasforConvertirViewModel selectedMonedas)
        {
            if (selectedNfts.IdsToAdd != null)
            {

                return RedirectToAction("Create", "Purchases", selectedNfts);
            }
            //a message error will be shown to the customer in case no movies are selected
            ModelState.AddModelError(string.Empty, "You must select at least one nft");

            //the View SelectMoviesForPurchase will be shown again
            return SelectNftsForPurchase(selectedNfts.TypeNFTSelected, selectedNfts.Price);
        }