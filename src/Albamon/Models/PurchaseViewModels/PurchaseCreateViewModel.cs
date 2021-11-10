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
        public string UserId
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

        public virtual IList<PurchaseNFTViewModel> PurchaseNFTs
        {
            get;
            set;
        }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Delivery Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, set your address for delivery")]

        public String DeliveryAddress
        {
            get;
            set;
        }

        [Display(Name = "Payment Method")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, select your payment method for delivery")]
        public String PaymentMethod
        {
            get;
            set;
        }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM/yyyy}")]
        public virtual DateTime? ExpirationDate { get; set; }

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
                  UserId == model.UserId &&
                  TotalPrice == model.TotalPrice &&
                  BuyDate == model.BuyDate &&
                  Email == model.Email &&
                  ExpirationDate == model.ExpirationDate;
            else
                return false;
            for (int i = 0; i < this.PurchaseNFTs.Count; i++)
                result = result && (this.PurchaseNFTs[i].Equals(model.PurchaseNFTs[i]));
            return result;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PaymentMethod == "CreditCard")
            {
                if (CreditCardNumber == null)
                    yield return new ValidationResult("Please, fill in your Credit Card Number for your Credit Card payment",
                        new[] { nameof(CreditCardNumber) });
                if (CCV == null)
                    yield return new ValidationResult("Please, fill in your CCV for your Credit Card payment",
                        new[] { nameof(CCV) });
                if (ExpirationDate == null)
                    yield return new ValidationResult("Please, fill in your ExpirationDate for your Credit Card payment",
                        new[] { nameof(ExpirationDate) });
            }
            else
            {
                if (Email == null)
                    yield return new ValidationResult("Please, fill in your Email for your PayPal payment",
                        new[] { nameof(Email) });
                if (Prefix == null)
                    yield return new ValidationResult("Please, fill in your Prefix for your PayPal payment",
                        new[] { nameof(Prefix) });
                if (Phone == null)
                    yield return new ValidationResult("Please, fill in your Phone for your PayPal payment",
                        new[] { nameof(Phone) });
            }

            //it is checked whether quantity is higher than 0 for at least one movie
            if (PurchaseItems.Sum(pi => pi.Quantity) <= 0)
                yield return new ValidationResult("Please, select Quantity higher than 0 for at least one movie",
                     new[] { nameof(PurchaseItems) });



        }
    }

    public class PurchaseNFTViewModel
    {
        public virtual int MovieID
        {
            get;
            set;
        }


        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public virtual String Title
        {
            get;
            set;
        }


        [Display(Name = "Price For Purchase")]
        public virtual int PriceForPurchase
        {
            get;
            set;
        }


        public virtual String Genre
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
            PurchaseItemViewModel purchaseItem = obj as PurchaseItemViewModel;
            bool result = false;
            if ((MovieID == purchaseItem.MovieID)
                && (this.PriceForPurchase == purchaseItem.PriceForPurchase)
                    && (this.Quantity == purchaseItem.Quantity)
                    && (this.Title == purchaseItem.Title))
                result = true;
            return result;
        }
    }
}
