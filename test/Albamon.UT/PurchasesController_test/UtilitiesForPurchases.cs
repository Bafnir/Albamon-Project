using Albamon.Data;
using Albamon.Models;
using Albamon.UT.NftsController_test;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albamon.UT.PurchasesController_test
{
    public static class UtilitiesForPurchases
    {
        public static void InitializeDbPurchasesForTests(ApplicationDbContext db)
        {
            var purchases = GetPurchases(0, 1);
            foreach (Purchase purchase in purchases)
            {
                db.Purchase.Add(purchase as Purchase);
            }
            db.SaveChanges();

        }

        public static void ReInitializeDbPurchasesForTests(ApplicationDbContext db)
        {
            db.PurchaseNFT.RemoveRange(db.PurchaseNFT);
            db.Purchase.RemoveRange(db.Purchase);
            db.SaveChanges();
        }

        public static IList<Purchase> GetPurchases(int index, int numOfPurchases)
        {

            Usuario usuario = Utilities.GetUsers(0, 1).First() as Usuario;
            var allPurchases = new List<Purchase>();
            Purchase purchase;
            NFT nft;
            PurchaseNFT purchaseNft;
            int quantity = 2;
            int fee = 6;

            for (int i = 1; i < 3; i++)
            {
                nft = UtilitiesForNfts.GetNfts(i - 1, 1).First();
                purchase = new Purchase
                {
                    PurchaseId = i,
                    User = usuario,
                    Fees = 1,
                    BuyDate = System.DateTime.Now,
                    TotalPrice = nft.Price,
                    PurchaseNFTS = new List<PurchaseNFT>()
                };
                purchaseNft = new PurchaseNFT
                {
                    Pid = i,
                    Quantity = quantity,
                    NFT = nft,
                    NftId = nft.NftId,
                    Fee = fee,
                    Purchase = purchase,
                    PurchaseId = purchase.PurchaseId

                };
                purchase.PurchaseNFTS.Add(purchaseNft);
                purchase.Fees = purchaseNft.Fee;
                purchase.TotalPrice = purchaseNft.Quantity * purchaseNft.NFT.Price;
                allPurchases.Add(purchase);

            }

            return allPurchases.GetRange(index, numOfPurchases);
        }

    }
}