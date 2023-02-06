
using System;
using System.Collections.Generic;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Product : Model
    {
        public string FaName { get; set; }
        public string EnName { get; set; }
        
        public string Information { get; set; }
        public DateTime CreateDate { get; set; }

        public long ClassificationID { get; set; }
        public Guid ClassificationGuID { get; set; }
        public string ClassificationName { get; set; }

        public long BrandID { get; set; }
        public Guid BrandGuID { get; set; }
        public string BrandFaName { get; set; }
        public string BrandEnName { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
