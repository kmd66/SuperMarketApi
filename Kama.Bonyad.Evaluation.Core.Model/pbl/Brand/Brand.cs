using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Brand : Model
    {
        public string FaName { get; set; }
        public string EnName { get; set; }
        public Attachment Attachment { get; set; }

    }
}
