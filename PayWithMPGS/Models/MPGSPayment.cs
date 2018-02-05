using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayWithMPGS.Models
{
    public class MPGSPayment
    {
        public MPGSPayment()
        {
            Amount = 10;
            Country = "India";
        }
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Required]
        [ReadOnly(true)]
        public double Amount { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [Display(Name="Card No")]
        public string CardNo { get; set; }
        [Required]
        [Display(Name = "Card Exp (MM)")]
        public int CardExpMonth { get; set; }
        [Required]        
        [Display(Name = "Card Exp (YY)")]
        public int CardExpYear { get; set; }
        public string ClientIP { get; set; }
        public bool Paid { get; set; }
        public string CheckSum { get; set; }
        public DateTime? TimeStampInitiated { get; set; }
        public DateTime? TimeStampSuccess { get; set; }
    }
}