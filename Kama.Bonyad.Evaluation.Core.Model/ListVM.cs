using Kama.AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ListVM
    {
        public Guid GuID { get; set; }

        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public List<SortExp> SortExp { get; set; }
    }
}
