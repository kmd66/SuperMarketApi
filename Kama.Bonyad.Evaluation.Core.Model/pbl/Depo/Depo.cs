
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Depo : Model
    {
        public int Number { get; set; }
        public long ItemID { get; set; }
        public long PriceBuy { get; set; }
        public long PriceSale { get; set; }
        public DepoType Type { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }

        public string FaName { get; set; }
        public string EnName { get; set; }
        public DateTime Expired { get; set; }
    }
}
