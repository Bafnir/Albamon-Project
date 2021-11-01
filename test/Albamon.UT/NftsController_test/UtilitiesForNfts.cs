using Albamon.Data;
using Albamon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albamon.UT.NftsController_test
{
    public static class UtilitiesForNfts
    {
        public static void InitializeDbTypeNftsForTests(ApplicationDbContext db)
        {
            db.TypeNFT.AddRange(GetTypeNfts(0, 3));
            db.SaveChanges();

        }

        public static void ReInitializeDbTypeNftsForTests(ApplicationDbContext db)
        {
            db.TypeNFT.RemoveRange(db.TypeNFT);
            db.SaveChanges();
        }

        public static void InitializeDbNftsForTests(ApplicationDbContext db)
        {

            //db.NFT.AddRange(GetNfts(0, 4));
            db.NFT.AddRange(GetNfts(0, 4));
            //genre id=1 it is already added because it is related to the movies
            //db.TypeNFT.AddRange(GetTypeNfts(0, 2));
            db.SaveChanges();

            db.Users.Add(new Usuario { Id = "1", UserName = "peter@uclm.com", PhoneNumber = "967959595", Email = "peter@uclm.com", Nombre = "Peter", Apellidos = "Jackson"});
            db.SaveChanges();
        }

        public static void ReInitializeDbNftsForTests(ApplicationDbContext db)
        {
            db.NFT.RemoveRange(db.NFT);
            db.TypeNFT.RemoveRange(db.TypeNFT);
            db.SaveChanges();
        }

        public static IList<NFT> GetNfts(int index, int numOfNfts)
        {
            TypeNFT type1 = GetTypeNfts(0, 1).First();
            TypeNFT type2 = GetTypeNfts(1, 1).First();
            var allNfts = new List<NFT>
            {
                new NFT { NftId = 1, Name = "CHOK", TypeNFT = type1, Price = 8, Health = 10, Attack = 5, Rarity = "High"},
                new NFT { NftId = 2, Name = "CHIK", TypeNFT = type1, Price = 10, Health = 10, Attack = 5, Rarity = "High"},
                new NFT { NftId = 3, Name = "CHUK", TypeNFT = type2, Price = 8, Health = 10, Attack = 5, Rarity = "High"},
                new NFT { NftId = 4, Name = "CHAAAAAAK", TypeNFT = type2, Price = 10, Health = 10, Attack = 5, Rarity = "High"},
            };

            return allNfts.GetRange(index, numOfNfts);
        }


        public static IList<TypeNFT> GetTypeNfts(int index, int numOfTypeNfts)
        {
            var allTypeNfts = new List<TypeNFT>
                {
                    new TypeNFT { Id=1, Description = "FIRE", Name = "FIRE", Tier = 1 } ,
                    new TypeNFT { Id=2, Description = "WATER", Name = "WATER", Tier = 1 },
                    new TypeNFT { Id=3, Description = "PLANT", Name = "PLANT", Tier = 1 }
                };
            //return from the list as much instances as specified in numOfGenres
            return allTypeNfts.GetRange(index, numOfTypeNfts);
        }
    }
}
