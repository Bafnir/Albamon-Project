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
using Microsoft.AspNetCore.Authorization;

namespace Albamon.Controllers
{
    [Authorize]
    public class NFTsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NFTsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NFTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NFT.ToListAsync());
        }

        // GET: NFTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT = await _context.NFT
                .FirstOrDefaultAsync(m => m.NftId == id);
            if (nFT == null)
            {
                return NotFound();
            }

            return View(nFT);
        }

        // GET: NFTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NFTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NftId,Name,Price,Health,Attack,Rarity")] NFT nFT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nFT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nFT);
        }

        // GET: NFTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT = await _context.NFT.FindAsync(id);
            if (nFT == null)
            {
                return NotFound();
            }
            return View(nFT);
        }

        // POST: NFTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NftId,Name,Price,Health,Attack,Rarity")] NFT nFT)
        {
            if (id != nFT.NftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nFT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NFTExists(nFT.NftId))
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
            return View(nFT);
        }

        // GET: NFTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT = await _context.NFT
                .FirstOrDefaultAsync(m => m.NftId == id);
            if (nFT == null)
            {
                return NotFound();
            }

            return View(nFT);
        }

        // POST: NFTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nFT = await _context.NFT.FindAsync(id);
            _context.NFT.Remove(nFT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NFTExists(int id)
        {
            return _context.NFT.Any(e => e.NftId == id);
        }

        //Get: Get NFTS FOR selection
        [HttpGet]
        public IActionResult SelectNftsForPurchase(string TypeNFTSelected, double Price)
        {
            SelectNftsForPurchasesViewModel selectnfts= new SelectNftsForPurchasesViewModel();
            selectnfts.TypeNFTs = new SelectList(_context.TypeNFT.Select(g => g.Name).ToList());
            selectnfts.NFTS = _context.NFT
                .Include(m => m.TypeNFT) //join table Nft and table typenft
                .Where(m => (m.Price <= Price || Price == 0)
                && (m.TypeNFT.Name.Contains(TypeNFTSelected) || TypeNFTSelected == null));

            selectnfts.NFTS = selectnfts.NFTS.ToList();
            return View(selectnfts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectNftsForPurchase(SelectedNftsForPurchaseViewModel selectedNfts)
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



    }
}
