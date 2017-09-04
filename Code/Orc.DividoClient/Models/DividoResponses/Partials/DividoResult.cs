
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Orc.Divido.Models.enums;

namespace Orc.Divido.Models.DividoResponses.Partials
{
    [DataContract()]
    public class DividoActivation
    {
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "comment")]
        public string comment { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "deliveryMethod")]
        public string DeliveryMethod { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "status")]
        public string Status_Str { get; set; }

        public DividoOrderStatus Status { get { return Calculators.DividoOrderStatusCalculator.FromDividoOrderStatus(Status_Str); } }

        [DataMember(Name = "trackingNumber")]
        public string TrackingNumber { get; set; }
    }
    [DataContract()]
    public class DividoLender
    {
        [DataMember(Name = "app")]
        public string App { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
    [DataContract()]
    public class DividoRefund
    {
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        [DataMember(Name = "comment")]
        public string Vomment { get; set; }
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
        [DataMember(Name = "reference")]
        public string Reference { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        
    }
    [DataContract()]
    public class DividoCancellation
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "status")]
        public string Status_Str { get; set; }

        public DividoOrderStatus Status { get { return Calculators.DividoOrderStatusCalculator.FromDividoOrderStatus(Status_Str); } }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }

    [DataContract()]
    public class DividoResult
    {
        [DataMember(Name = "creditAmount")]
        public decimal CreditAmount { get; set; }

        [DataMember(Name = "depositAmount")]
        public decimal depositAmount { get; set; }

        [DataMember(Name = "depositStatus")]
        public string DepositStatus { get; set; }

        [DataMember(Name = "activatedAmount")]
        public decimal ActivatedAmount { get; set; }

        [DataMember(Name = "activationStatus")]
        public string ActivationStatus { get; set; }

        [DataMember(Name = "activations")]
        public List<DividoActivation> Activations { get; set; }

        [DataMember(Name = "cancelledAmount")]
        public decimal cancelledAmount { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "lender")]
        public DividoLender Lender { get; set; }

        [DataMember(Name = "purchasePrice")]
        public decimal PurchasePrice { get; set; }

        [DataMember(Name = "refundedAmount")]
        public decimal RefundedAmount { get; set; }

        [DataMember(Name = "status")]
        public string Status_Str { get; set; }

        public DividoOrderStatus Status { get { return Calculators.DividoOrderStatusCalculator.FromDividoOrderStatus(Status_Str); } }

        [DataMember(Name = "refunds")]
        public List<DividoRefund> Refunds { get; set; }

        [DataMember(Name = "cancellations")]
        public List<DividoCancellation> Cancellations { get; set; }
    }
}
