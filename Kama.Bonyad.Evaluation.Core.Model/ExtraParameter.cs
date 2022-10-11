using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Mefa.Daadkhahi.Core.Model
{
    public class ExtraParameter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string SortExp { get; set; }

        public ActionState ActionState { get; set; }

        public Guid? UserPositionId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
