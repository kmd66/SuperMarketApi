using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ItemVM : ListVM
    {
        public long ClassificationID { get; set; }
        public long BrandID { get; set; }
        public string FaName { get; set; }
        public string EnName { get; set; }
        public bool IsAttachment { get; set; }
    }
}
