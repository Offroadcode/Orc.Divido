using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoDealCalculatorResponse : _BaseDividoResponse
    {
        [DataMember(Name = "purchase_price")]
        public decimal PurchasePrice { get; set; }

        [DataMember(Name = "deposit_amount")]
        public decimal DepositAmount { get; set; }

        [DataMember(Name = "credit_amount")]
        public decimal CreditAmount { get; set; }

        [DataMember(Name = "monthly_payment_amount")]
        public decimal MonthlyPaymentAmount { get; set; }

        [DataMember(Name = "total_repayable_amount")]
        public decimal TotalRepayableAmount { get; set; }

        [DataMember(Name = "agreement_duration")]
        public int AgreementDuration { get; set; }

        [DataMember(Name = "interest_rate")]
        public decimal InterestRate { get; set; }

        [DataMember(Name = "interest_type")]
        public string InterestType { get; set; }
    }
   
}
