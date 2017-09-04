using System;
using System.Collections.Generic;
using System.Text;

namespace Orc.Divido.Models.enums
{
    public enum DividoOrderStatus
    {
        /// <summary>
        /// Proposal send to Underwriter, waiting for decision
        /// </summary>
        DRAFT,
        /// <summary>
        /// Application accepted by Underwriter
        /// </summary>
        ACCEPTED,
        /// <summary>
        /// Applicaiton declined by Underwriter
        /// </summary>
        DECLINED,
        /// <summary>
        /// Application referred by Underwriter, waiting for new status
        /// </summary>
        REFERRED,
        /// <summary>
        /// More information is required before decision
        /// </summary>
        INFO_NEEDED,
        /// <summary>
        /// Waiting for more information from Customer
        /// </summary>
        ACTION_CUSTOMER,
        /// <summary>
        /// Waiting for more information from Merchant
        /// </summary>
        ACTION_RETAILER,
        /// <summary>
        /// Waiting for more information from Underwriter
        /// </summary>
        ACTION_LENDER,
        /// <summary>
        /// Deposit paid by customer
        /// </summary>
        DEPOSIT_PAID,
        /// <summary>
        /// Customer has signed all contracts
        /// </summary>
        SIGNED,
        /// <summary>
        /// Waiting for confirmation from Underwriter
        /// </summary>
        AWAITING_ACTIVATION,
        /// <summary>
        /// Waiting for confirmation from Underwriter
        /// </summary>
        AWAITING_CANCELLATION,
        /// <summary>
        /// Application partially activated by merchant
        /// </summary>
        PARTIALLY_ACTIVATED,
        /// <summary>
        /// Application activated and confirmed by Underwriter
        /// </summary>
        ACTIVATED,
        /// <summary>
        /// Application cancelled
        /// </summary>
        CANCELLED,
        /// <summary>
        /// Whole Application refunded
        /// </summary>
        REFUNDED,
        /// <summary>
        /// Dispute raised by Merchant or Underwriter
        /// </summary>
        DISPUTED,
        /// <summary>
        /// Loan reversal in progress
        /// </summary>
        LOAN_REVERSAL,
        /// <summary>
        /// Application completed(after cool down period)
        /// </summary>
        COMPLETED,
    }
}
