using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbRequest
    {
        public Guid RequestId { get; set; }
        public string Status { get; set; }
        public int? BiancePayId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public int? SubscriptionFee { get; set; }
        public int? PdfFee { get; set; }
        public int? TotalProfit { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionPeriod { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public DateTime? DateofAction { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public int? RemainingTime { get; set; }
    }
}
