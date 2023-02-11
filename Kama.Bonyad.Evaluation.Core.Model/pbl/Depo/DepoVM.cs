using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class DepoVM : ListVM
    {
        public long ItemID { get; set; }
        public DepoType Type { get; set; }
        public string Comment { get; set; }
    }
}
