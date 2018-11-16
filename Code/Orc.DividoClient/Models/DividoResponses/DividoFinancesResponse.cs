using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Orc.Divido.Models.DividoResponses
{
    [DataContract()]
    public class DividoFinancesResponse :_BaseDividoResponse
    {
        [DataMember(Name = "finances")]
        public List<DividoFinance> Finances { get; set; }   
    }

    [DataContract()]
    public class DividoFinance
    {
        [DataMember(Name = "agreement_duration")]
        public int AgreementDuration { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "deferral_period")]
        public int DeferralPeriod { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "instalment_fee")]
        public decimal InstalmentFee { get; set; }

        [DataMember(Name = "interest_rate")]
        public decimal InterestRate { get; set; }

        [DataMember(Name = "max_deposit")]
        public decimal MaxDeposit { get; set; }

        [DataMember(Name = "min_amount")]
        public decimal MinAmount { get; set; }

        [DataMember(Name = "min_deposit")]
        public decimal MinDeposit { get; set; }

        [DataMember(Name = "setup_fee")]
        public decimal SetupFee { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
