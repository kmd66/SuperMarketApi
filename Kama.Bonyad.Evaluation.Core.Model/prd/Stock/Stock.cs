
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Stock
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public long ClassificationID { get; set; }
        public string ClassificationName { get; set; }
        public DateTime Date { get; set; }
        public Guid CreatorID { get; set; }
        public string FromPositionName { get; set; }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }
    }
}
