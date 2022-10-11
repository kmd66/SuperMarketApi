using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
   public class GetListActionVM : ListVM
    {
        public Guid ControllerID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}
