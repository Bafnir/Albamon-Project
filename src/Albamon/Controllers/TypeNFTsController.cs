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
    public class TypeNFTsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeNFTsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeNFTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeNFT.ToListAsync());
        }

        // GET: TypeNFTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNFT = await _context.TypeNFT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeNFT == null)
            {
                return NotFound();
            }

            return View(typeNFT);
        }

        // GET: TypeNFTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeNFTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Name,Tier")] TypeNFT typeNFT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeNFT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeNFT);
        }

        // GET: TypeNFTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNFT = await _context.TypeNFT.FindAsync(id);
            if (typeNFT == null)
            {
                return NotFound();
            }
            return View(typeNFT);
        }

        // POST: TypeNFTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name,Tier")] TypeNFT typeNFT)
        {
            if (id != typeNFT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeNFT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeNFTExists(typeNFT.Id))
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
            return View(typeNFT);
        }

        // GET: TypeNFTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeNFT = await _context.TypeNFT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeNFT == null)
            {
                return NotFound();
            }

            return View(typeNFT);
        }

        // POST: TypeNFTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeNFT = await _context.TypeNFT.FindAsync(id);
            _context.TypeNFT.Remove(typeNFT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeNFTExists(int id)
        {
            return _context.TypeNFT.Any(e => e.Id == id);
        }
    }
}
