using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Brand : Model
    {
        public long ParentID { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }

    }
}
