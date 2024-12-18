using OrisonCollegePortal.Shared.Entities.Finance;

namespace OrisonCollegePortal.Shared.Entities.Finance
{
    public class dtsVoucher
    {
        public dtVoucher? voucher { get; set; }

        public dtVoucherEntry? voucherentry { get; set; }

        public dtVoucherEntry[]? objvtemp { get; set; }
        public dtVoucherEntry[]? objvtempDisc { get; set; }

        public dtPostingVoucher[]? objpostvoucherTemp { get; set; }
        public dtDeleteVoucher? objdepostvoucherTemp { get; set; }
        public dtParam? ParamEnrty { get; set; }
        public List<dtBulkPost>? MassDepost { get; set; }

    }
}
