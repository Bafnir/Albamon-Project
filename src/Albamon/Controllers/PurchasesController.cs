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
using Albamon.Models.PurchaseViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Albamon.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Purchase
                .Include(p => p.User)
                .Where(p => p.User.Email == User.Identity.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .Include(p => p.User)
                .Include(p => p.PurchaseNFTS).ThenInclude(p => p.NFT)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create(SelectedNftsForPurchaseViewModel selectedNfts)
        {
            PurchaseCreateViewModel purchase = new();
            purchase.PurchaseNFTs = new List<PurchaseNFTViewModel>();

            if (selectedNfts.IdsToAdd == null)
            {
                ModelState.AddModelError("NftNoSelected", "You should select at least a NFT to be purchased, please");
            }
            else
                purchase.PurchaseNFTs = _context.NFT.Include(NFT => NFT.TypeNFT)
                    .Select(NFT => new PurchaseNFTViewModel()
                    {
                        NftId = NFT.NftId,
                        TypeNFT = NFT.TypeNFT.Name,
                        Price = NFT.Price,
                        Name = NFT.Name
                    })
                    .Where(NFT => selectedNfts.IdsToAdd.Contains(NFT.NftId.ToString())).ToList();

            Usuario usuario= _context.Users.OfType<Usuario>().FirstOrDefault<Usuario>(u => u.UserName.Equals(User.Identity.Name));
            purchase.Nombre = usuario.Nombre;
            purchase.Apellidos = usuario.Apellidos;
            return View(purchase);
        }



        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PurchaseId,TotalPrice,BuyDate")] Purchase purchase)
        //{
        /*    if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }
        */
        //nuevo
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(PurchaseCreateViewModel purchaseViewModel)
        {
            NFT nft; PurchaseNFT purchaseNFT;
            Usuario usuario;
            Purchase purchase = new();
            purchase.TotalPrice = 0;
            purchase.PurchaseNFTS = new List<PurchaseNFT>();
            usuario = await _context.Users.OfType<Usuario>().FirstOrDefaultAsync<Usuario>(u => u.UserName.Equals(User.Identity.Name));


            if (ModelState.IsValid)
            {
                foreach (PurchaseNFTViewModel item in purchaseViewModel.PurchaseNFTs)
                {
                    nft = await _context.NFT.FirstOrDefaultAsync<NFT>(m => m.NftId == item.NftId);
                    if (item.Quantity > 0) {
                        purchaseNFT = new PurchaseNFT
                        {
                            NFT = nft,
                            Purchase = purchase,
                            Quantity = item.Quantity,
                            Fee = purchaseViewModel.Fee
                    };

                        purchase.TotalPrice += item.Quantity * nft.Price;
                        purchase.PurchaseNFTS.Add(purchaseNFT);
                    }
                }
            }
            purchase.Fees = purchaseViewModel.Fee;
            if (purchase.Fees < 2)
            {
                ModelState.AddModelError("", $"The amount of fee introduced is not enough, please select more than 2");
            }

            if (ModelState.ErrorCount > 0)
            {
                purchaseViewModel.Nombre = usuario.Nombre;
                purchaseViewModel.Apellidos = usuario.Apellidos;
                return View(purchaseViewModel);
            }


            purchase.User = usuario;
            purchase.BuyDate = DateTime.Now;
            _context.Add(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = purchase.PurchaseId });
        }

        //fin nuevo

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,TotalPrice,BuyDate")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
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
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.PurchaseId == id);
        }
    }
}
