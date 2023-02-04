using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class BrandVM : ListVM
    {
        public long ParentID { get; set; }
        public string FaName { get; set; }
        public string EnName { get; set; }
        public bool IsAttachment { get; set; }

    }
}
