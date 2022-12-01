
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class StockVM: ListVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long ClassificationID { get; set; }
        public StockActionState ActionState { get; set; }
    }
}
