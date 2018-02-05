using Newtonsoft.Json;
using PayWithMPGS.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace PayWithMPGS.Services
{
    public class PaymentService
    {
        public bool PayWithPaymentGateway(MPGSPayment model,string cVV)
        {
            String result = null;
            String gatewayCode = null;
            String response = null;

            // get the request form and make sure to UrlDecode each value in case special characters used
            NameValueCollection formData = new NameValueCollection();
            
            formData.Add("order.id", HttpUtility.UrlDecode(model.OrderId));
            formData.Add("transaction.id", HttpUtility.UrlDecode(model.OrderId));
            formData.Add("apiOperation", HttpUtility.UrlDecode("PAY"));
            formData.Add("sourceOfFunds.type", HttpUtility.UrlDecode("CARD"));
            formData.Add("sourceOfFunds.provided.card.number", HttpUtility.UrlDecode(model.CardNo.ToString()));
            formData.Add("sourceOfFunds.provided.card.expiry.month", HttpUtility.UrlDecode(model.CardExpMonth.ToString()));
            formData.Add("sourceOfFunds.provided.card.expiry.year", HttpUtility.UrlDecode(model.CardExpYear.ToString()));
            formData.Add("sourceOfFunds.provided.card.securityCode", HttpUtility.UrlDecode(cVV));
            formData.Add("order.amount", HttpUtility.UrlDecode(model.Amount.ToString()));
            formData.Add("order.currency", HttpUtility.UrlDecode("AED"));

            // get merchant information from web.config
            Merchant merchant = new Merchant();

            // [Snippet] howToConfigureURL - start
            StringBuilder url = new StringBuilder();
            if (!merchant.GatewayHost.StartsWith("http"))
                url.Append("https://");
            url.Append(merchant.GatewayHost);
            url.Append("/api/rest/version/");
            url.Append(merchant.Version);
            url.Append("/merchant/");
            url.Append(merchant.MerchantId);
            url.Append("/order/");
            url.Append(formData["order.id"]);
            url.Append("/transaction/");
            url.Append(formData["transaction.id"]);
            merchant.GatewayUrl = url.ToString();
            // [Snippet] howToConfigureURL - end

            // remove these two fields as they are passed in URL for REST/JSON implementation
            formData.Remove("order.id");
            formData.Remove("transaction.id");

            // [Snippet] howToConvertFormData -- start
            String data = Json.BuildJsonFromNVC(formData);
            // [Snippet] howToConvertFormData -- end

            // open connection
            Connection connection = new Connection(merchant);

            // send request/get results
            String operation = formData["apiOperation"];
            if (operation.Equals("RETRIEVE_TRANSACTION"))
            {
                response = connection.GetTransaction();
            }
            else
            {
                response = connection.SendTransaction(data);
            }

            //I am saving the whole response here you can make whatever use of it...
            var responseObj= JsonConvert.DeserializeObject<PaymentResponse>(response);

            if (responseObj.result == "SUCCESS")
                return true;

            return false;
        }
    }
}