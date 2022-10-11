
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ProductClassification : Model
    {
        public string Node { get; set; }
        public string NodeString { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Guid? ParentID { get; set; }
        public string ParentName { get; set; }
        public Attachment Attachment { get; set; }
    }
}
