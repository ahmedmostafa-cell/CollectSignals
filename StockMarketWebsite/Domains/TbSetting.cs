using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSetting
    {
        public string SettingId { get; set; }
        public Guid SubTrialFee { get; set; }
        public string SubProWeeklyFee { get; set; }
        public string SubProMonthlyFee { get; set; }
        public string PdfStrategyFee { get; set; }
        public string BiancePayId { get; set; }
        public string QrCodeFile { get; set; }
        public string StrategyFile { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
