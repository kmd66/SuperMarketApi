using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ProductClassificationVM : ListVM
    {
        public Guid? ParentID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool AllChild { get; set; }
        public bool IsAttachment { get; set; }
    }
}
