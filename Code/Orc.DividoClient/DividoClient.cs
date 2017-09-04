using System;
using System.Collections.Generic;
using Orc.Divido;
using Orc.Divido.Calculators;
using Orc.Divido.Models.DividoResponses;
using Orc.Divido.Models.DividoResponses.Partials;
using Orc.Divido.Models.enums;
using Orc.Divido.Requestor;

namespace Orc.Divido
{
    public class DividoClient
    {
        private const string ApiVersion = "v1";

        public DividoClient(string apiKey)
        {
            ApiKey = apiKey;
            Environment = DividoEnvCalculator.Calculate(apiKey);
            BaseUrl = BaseUrlCalculator.Calculate(Environment);
        }

        public DividoClient(string apiKey, DividoEnvironment environment)
        {
            ApiKey = apiKey;
            Environment = environment;
            BaseUrl = BaseUrlCalculator.Calculate(Environment);
          
        }

        public DividoClient(string apiKey, DividoEnvironment environment, string baseEndpointUrl)
        {
            ApiKey = apiKey;
            Environment = environment;
            BaseUrl = baseEndpointUrl;
        }

        private IDividoRequestor _Requestor = null;
        public IDividoRequestor Requestor {
            get
            {
                if(_Requestor == null)
                {
                    _Requestor = new DividoRequestor(ApiKey, BaseUrl, ApiVersion);
                }
                return _Requestor;
            }
        }

        public string ApiKey { get; private set; }
        public DividoEnvironment Environment { get; private set; }
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Returns an array with all finance options available for merchant
        /// </summary>
        /// <param name="country">The country code</param>
        public DividoFinancesResponse Finances(string country = null)
        {
            return Requestor.Get<DividoFinancesResponse>("finances", new Dictionary<string, string>() { { "country", country } });
        }

        /// <summary>
        /// The deal calculator calculates the payment terms for various terms and deposits.
        /// </summary>
        /// <param name="Amount">The total value of the order</param>
        /// <param name="deposit">The value of the deposit.</param>
        /// <param name="country">The country code</param>
        /// <param name="financeId">The finance code</param>
        public DividoDealCalculatorResponse DealCalcualator(decimal amount, decimal deposit, string country, string financeId)
        {
            //GET https://secure.divido.com/v1/dealcalculator?merchant={MERCHANT}&amount={AMOUNT}&deposit={deposit}&country={country}&finance={FINANCE} HTTP/1.1
            return Requestor.Get<DividoDealCalculatorResponse>("dealcalculator", new Dictionary<string, string>() {
                { "amount", amount.ToString() },
                { "deposit", deposit.ToString() },
                { "country", country },
                { "finance",financeId }
            });
        }

        /// <summary>
        /// The credit request creates a new proposal and return a URL to the Divido application form.
        /// </summary>
        /// <param name="deposit"></param>
        /// <param name="financeId"></param>
        /// <param name="countryCode"></param>
        /// <param name="language"></param>
        /// <param name="totalAmount"></param>
        /// <param name="reference"></param>
        /// <param name="currency"></param>
        /// <param name="customer"></param>
        /// <param name="products"></param>
        /// <param name="directSign"></param>
        /// <param name="responseUrl"></param>
        /// <param name="checkoutUrl"></param>
        /// <param name="redirectUrl"></param>
        public DividoCreditRequestResponse CreditRequest(decimal deposit, string financeId, string countryCode, string language, decimal totalAmount, string reference, string currency, DividoCustomer customer,List<DividoProduct> products, bool directSign = true, string responseUrl = null, string checkoutUrl = null, string redirectUrl = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("deposit", deposit.ToString());
            parameters.Add("finance", financeId);
            
            parameters.Add("directSign", directSign.ToString());
            parameters.Add("country", countryCode);
            parameters.Add("language", language);
            parameters.Add("currency", currency);
            parameters.Add("amount", totalAmount.ToString());
            parameters.Add("reference", reference);

            PostDataCalculator.Merge(ref parameters, customer, "customer");
            PostDataCalculator.Merge(ref parameters, new List<IConvertibleToPostData>(products), "products");


            parameters.Add("responseUrl", responseUrl);
            parameters.Add("checkoutUrl", checkoutUrl);
            parameters.Add("redirectUrl", redirectUrl);

            return Requestor.Post<DividoCreditRequestResponse>("creditrequest", parameters);

        }

        /// <summary>
        /// Finalize an existing accepted credit application,
        /// will update the loan agreement and return an url to the contract signing. 
        /// This only applies to Credit Requests created directSign = false.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="deposit"></param>
        /// <param name="financeId"></param>
        /// <param name="amount"></param>
        /// <param name="products"></param>
        /// <param name="redirectUrl"></param>
        public DividoFinalizeCreditRequestResponse FinalizeCreditRequest(string applicationId, decimal deposit, string financeId,decimal amount, List<DividoProduct> products, string redirectUrl)
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("application", applicationId);
            parameters.Add("deposit", deposit.ToString());

            parameters.Add("finance", financeId.ToString());
            parameters.Add("amount", amount.ToString());
            parameters.Add("redirectUrl", redirectUrl);

            PostDataCalculator.Merge(ref parameters, new List<IConvertibleToPostData>(products), "products");

            return Requestor.Post<DividoFinalizeCreditRequestResponse>("creditrequest/finalize", parameters);
            
        }

        /// <summary>
        /// /// Activate whole or part of an application and initialise a payout from the underwriter.
        /// Activate part of the application by specifing the products that should be activated.
        /// If no product data is submitted, the whole application will be activated.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="amount"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="trackingNumber"></param>
        /// <param name="reference"></param>
        /// <param name="comment"></param>
        /// <param name="products"></param>
        public DividoActivationResponse Activation(string applicationId, decimal amount, string deliveryMethod, string trackingNumber, string reference, string comment, List<DividoProduct> products = null)
        {
            
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("application", applicationId);
            parameters.Add("amount", amount.ToString());
            parameters.Add("deliveryMethod", deliveryMethod);
            parameters.Add("trackingNumber", trackingNumber);
            parameters.Add("reference", reference);
            parameters.Add("comment", comment);

            if (products != null)
            {
                PostDataCalculator.Merge(ref parameters, new List<IConvertibleToPostData>(products), "products");
            }

            return Requestor.Post<DividoActivationResponse>("activation", parameters);
        }

        /// <summary>
        /// Mark an application as cancelled and notify the underwriter,
        /// only possible if application is 
        /// DRAFT, 
        /// REFERRED, 
        /// INFO-NEEDED, 
        /// ACTION-CUSTOMER, 
        /// ACTION-RETAILER, 
        /// ACTION-LENDER, 
        /// ACCEPTED, 
        /// DEPOSIT-PAID, 
        /// PARTIALLY-ACTIVATED, 
        /// SIGNED.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="amount"></param>
        /// <param name="reference"></param>
        /// <param name="comment"></param>
        /// <param name="products"></param>
        public DividoCancellationResponse Cancellation(string applicationId, decimal amount, string reference, string comment, List<DividoProduct> products)
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("application", applicationId);
            parameters.Add("amount", amount.ToString());
            parameters.Add("reference", reference);
            parameters.Add("comment", comment);

            PostDataCalculator.Merge(ref parameters, new List<IConvertibleToPostData>(products), "products");

            return Requestor.Post<DividoCancellationResponse>("cancellation", parameters);
        }

        /// <summary>
        /// Refund whole or part of an application,
        /// if the application is AWAITING-ACTIVATION, PARTIALLY-ACTIVATED, ACTIVATED or COMPLETED. 
        /// For partial refund, specify the products that have been refunded. 
        /// If no product data is submitted the whole application will be refunded.
        /// </summary>
        public DividoRefundResponse Refund(string applicationId, decimal amount, string reference, string comment, List<DividoProduct> products)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("application", applicationId);
            parameters.Add("amount", amount.ToString());
            parameters.Add("reference", reference);
            parameters.Add("comment", comment);

            if (products != null)
            {
                PostDataCalculator.Merge(ref parameters, new List<IConvertibleToPostData>(products), "products");
            }
            return Requestor.Post<DividoRefundResponse>("cancellation", parameters);
        }

        /// <summary>
        /// Returns a list of your applications. The applications are returned sorted by creation date, with the most recently created applications appearing first.
        /// </summary>
        /// <param name="countryCode">Filter by country code</param>
        /// <param name="status">Filter by status</param>
        /// <param name="proposal">Filter by proposal</param>
        /// <param name="page">Show page</param>
        public DividoListAllApplicationsResponse ListAllApplications(string countryCode = null, DividoOrderStatus? status = null, string proposalId = null, int page = 1)
        {
            
            return Requestor.Get<DividoListAllApplicationsResponse>("applications", new Dictionary<string, string>() {
                { "countryCode", countryCode},
                { "status", Calculators.DividoOrderStatusCalculator.ToDividoStatusString(status)},
                { "proposalId", proposalId},
                { "page", page.ToString()  }
            });
        }

        /// <summary>
        /// Retrieves the details of an existing application. Supply the application ID and the API will return the corresponding application.
        /// </summary>
        /// <param name="id">Application id</param>
        public DividoGetApplicationResponse RetrieveApplication(string id)
        {
            return Requestor.Get<DividoGetApplicationResponse>("applications", new Dictionary<string, string>() {
                { "id", id}
            });
        }
        /*
        /// <summary>
        /// Retrieves all payment batches.
        /// </summary>
        /// <param name="currency"> Filter by currency code</param>
        /// <param name="lenderId">Filter by lender ID</param>
        /// <param name="page">show page, default 1</param>
        public void Reporting_PaymentBatches(string currency = null, string lenderId = null, int page =1)
        {
         
        }

        /// <summary>
        /// Retrieves the content of a payment batch. Supply the batch ID and the API will return all records.
        /// </summary>
        /// <param name="id">Batch id</param>
        public void Reporting_PaymentBatche(Guid id)
        {
            return Requestor.Get<DividoGetApplicationResponse>("applications", new Dictionary<string, string>() {
                { "id", id}
            });
        }
        */
    }
}
