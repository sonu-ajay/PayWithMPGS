using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayWithMPGS.Models
{
    public class AuthorizationResponse
    {
        public string cardLevelIndicator { get; set; }
        public string commercialCard { get; set; }
        public string commercialCardIndicator { get; set; }
        public string marketSpecificData { get; set; }
        public string processingCode { get; set; }
        public string responseCode { get; set; }
        public string returnAci { get; set; }
        public string stan { get; set; }
        public string transactionIdentifier { get; set; }
        public string validationCode { get; set; }
    }

    public class Order
    {
        public double amount { get; set; }
        public DateTime creationTime { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public double totalAuthorizedAmount { get; set; }
        public double totalCapturedAmount { get; set; }
        public double totalRefundedAmount { get; set; }
    }

    public class Response
    {
        public string acquirerCode { get; set; }
        public string acquirerMessage { get; set; }
        public string gatewayCode { get; set; }
    }

    public class Expiry
    {
        public string month { get; set; }
        public string year { get; set; }
    }

    public class Card
    {
        public string brand { get; set; }
        public Expiry expiry { get; set; }
        public string fundingMethod { get; set; }
        public string number { get; set; }
        public string scheme { get; set; }
    }

    public class Provided
    {
        public Card card { get; set; }
    }

    public class SourceOfFunds
    {
        public Provided provided { get; set; }
        public string type { get; set; }
    }

    public class Acquirer
    {
        public int batch { get; set; }
        public string date { get; set; }
        public string id { get; set; }
        public string merchantId { get; set; }
        public string transactionId { get; set; }
    }

    public class Transaction
    {
        public Acquirer acquirer { get; set; }
        public double amount { get; set; }
        public string authorizationCode { get; set; }
        public string currency { get; set; }
        public string frequency { get; set; }
        public string id { get; set; }
        public string receipt { get; set; }
        public string source { get; set; }
        public string terminal { get; set; }
        public string type { get; set; }
    }

    public class PaymentResponse
    {
        public AuthorizationResponse authorizationResponse { get; set; }
        public string gatewayEntryPoint { get; set; }
        public string merchant { get; set; }
        public Order order { get; set; }
        public Response response { get; set; }
        public string result { get; set; }
        public SourceOfFunds sourceOfFunds { get; set; }
        public DateTime timeOfRecord { get; set; }
        public Transaction transaction { get; set; }
        public string version { get; set; }
    }
}