
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Product : Model
    {
        public long ParentID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Information { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid ClassificationGuID { get; set; }
        public string ClassificationName { get; set; }
        public Attachment Attachment { get; set; }
    }
}

