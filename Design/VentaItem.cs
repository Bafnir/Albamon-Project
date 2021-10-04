using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace Albamon.Models
{
    public class VentaItem
    {

        [ForeignKey("NFT")]
        public virtual NFT NFT
        {
            get;
            set;
        }

        [Range(1, Double.MaxValue, ErrorMessage = "You must provide a valid quantity")]
        public virtual int Quantity
        {
            get;
            set;
        }

        public virtual int NFTID
        {
            get;
            set;
        }
        [ForeignKey("PurchaseID")]
        public virtual Purchase Purchase
        {
            get;
            set;
        }

        public virtual int PurchaseID
        {
            get;
            set;
        }

      
    }

}