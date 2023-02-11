
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class DepoIndex : Model
    {
        public long ItemID { get; set; }
        public int Number { get; set; }
        public int NumberEnter { get; set; }
        public int NumberLeave { get; set; }
        public long LastPriceBuy { get; set; }
        public long AveragePriceBuy { get; set; }
        public long LastPriceSale { get; set; }
        public long AveragePriceSale { get; set; }
        public DepoType Type { get; set; }
        public string FaName { get; set; }
    }
}