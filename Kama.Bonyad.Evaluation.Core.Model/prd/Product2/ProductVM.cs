using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ProductVM2 : ListVM
    {
        public long ParentID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public long StartPrice { get; set; }
        public long EndPrice { get; set; }
        public bool IsAttachment { get; set; }
    }
}
