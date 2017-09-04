using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Models.DividoResponses.Partials;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoListAllApplicationsResponse : _BaseDividoResponse
    {

        [DataMember(Name = "itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [DataMember(Name = "itemsPerPage")]
        public int Page { get; set; }

        [DataMember(Name = "records")]
        public List<DividoListAllApplicationsRecord> Records { get; set; }

        [DataMember(Name = "totalItems")]
        public int TotalItems { get; set; }
    }
    [DataContract()]
    public class DividoChannel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract()]
    public class DividoFinanceSnippet
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "maxDeposit")]
        public decimal MaxDeposit { get; set; }

        [DataMember(Name = "minAmount")]
        public decimal MinAmount { get; set; }

        [DataMember(Name = "minDeposit")]
        public decimal MinDeposit { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
    [DataContract()]
    public class DividoHistory
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "status")]
        public string Status_Str { get; set; }

        public DividoOrderStatus Status { get { return Calculators.DividoOrderStatusCalculator.FromDividoOrderStatus(Status_Str); } }


        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }
    }

    [DataContract()]
    public class DividoListAllApplicationsRecord
    {
       
        public int activatableAmount { get; set; }

        public double activatedAmount { get; set; }
        
        public List<DividoActivation> activations { get; set; }

        public int agreementDuration { get; set; }
        public int cancelableAmount { get; set; }
        public List<object> cancellations { get; set; }
        public int cancelledAmount { get; set; }
        public DividoChannel channel { get; set; }
        public string country { get; set; }
        public DateTime createdDate { get; set; }
        public double creditAmount { get; set; }
        public double currentCreditAmount { get; set; }
        public string currency { get; set; }
        public int deferralPeriod { get; set; }
        public int depositAmount { get; set; }
        public string depositReference { get; set; }
        public string depositStatus { get; set; }
        public bool directSign { get; set; }
        public string email { get; set; }
        public DividoFinanceSnippet finance { get; set; }
        public string firstName { get; set; }
        public List<DividoHistory> history { get; set; }
        public string id { get; set; }
        public bool identityVerified { get; set; }
        public int interestRate { get; set; }
        public string interestType { get; set; }
        public string lastName { get; set; }
        public string lender { get; set; }
        public string lenderReference { get; set; }
        
        public DateTime modifiedDate { get; set; }
        public double monthlyPaymentAmount { get; set; }
        public List<DividoProduct> products { get; set; }
        public string proposal { get; set; }
        public object proposalCreator { get; set; }
        public double purchasePrice { get; set; }
        public string reference { get; set; }
        public double refundableAmount { get; set; }
        public int refundedAmount { get; set; }
        public List<DividoRefund> refunds { get; set; }
        public string status { get; set; }
        public double totalRepayableAmount { get; set; }
    }
}
