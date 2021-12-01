using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models.PurchaseViewModels
{
    public class PurchaseCreateViewModel : IValidatableObject
    {
        public virtual string Nombre
        {
            get;
            set;
        }
        [Display(Name = "Apellidos")]
        public virtual string Apellidos
        {
            get;
            set;
        }

        [Display(Name = "DNI")]
        public virtual string DNI
        {
            get;
            set;
        }

        //It will be necessary whenever we need a relationship with ApplicationUser or any child class
        public string UsuarioId
        {
            get;
            set;
        }

        public double TotalPrice
        {
            get;
            set;
        }

        public DateTime BuyDate
        {
            get;
            set;
        }

        [DataType(DataType.Text)]
        [Display(Name = "Gas fee")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, set your gas fee")]

        public double Fee
        {
            get;
            set;
        }

        public virtual IList<PurchaseNFTViewModel> PurchaseNFTs
        {
            get;
            set;
        }

        [EmailAddress]
        public string Email { get; set; }

        public PurchaseCreateViewModel()
        {

            PurchaseNFTs = new List<PurchaseNFTViewModel>();
        }

        public override bool Equals(object obj)
        {
            bool result;
            if (obj is PurchaseCreateViewModel model)
                result = Nombre == model.Nombre &&
                  Apellidos == model.Apellidos &&
                  UsuarioId == model.UsuarioId &&
                  Fee == model.Fee &&
                  TotalPrice == model.TotalPrice &&
                  BuyDate == model.BuyDate &&
                  Email == model.Email;
            else
                return false;
            for (int i = 0; i < this.PurchaseNFTs.Count; i++)
                result = result && (this.PurchaseNFTs[i].Equals(model.PurchaseNFTs[i]));
            return result;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                if (Fee == null)
                    yield return new ValidationResult("Please, always imput a fee, it is required for the blockchain to complete the transaction",
                        new[] { nameof(Fee) });
            //it is checked whether quantity is higher than 0 for at least one movie
            if (PurchaseNFTs.Sum(pi => pi.Quantity) <= 0)
                yield return new ValidationResult("Please, select Quantity higher than 0 for at least one movie",
                     new[] { nameof(PurchaseNFTs) });
        }
    }

    public class PurchaseNFTViewModel
    {
        public virtual int NftId
        {
            get;
            set;
        }


        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public virtual String Name
        {
            get;
            set;
        }


        [Display(Name = "Price For Purchase")]
        public virtual double Price
        {
            get;
            set;
        }


        public virtual String TypeNFT
        {
            get;
            set;
        }

        [Required]
        public virtual int Quantity
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            PurchaseNFTViewModel purchaseNft = obj as PurchaseNFTViewModel;
            bool result = false;
            if ((NftId == purchaseNft.NftId)
                && (this.Price == purchaseNft.Price)
                    && (this.Quantity == purchaseNft.Quantity)
                    && (this.Name == purchaseNft.Name))
                result = true;
            return result;
        }
    }
}
