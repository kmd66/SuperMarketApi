using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Attachment : Model
    {
        public Guid? ParentID { get; set; }

        public AttachmentType Type { get; set; }

        public DateTime CreationDate { get; set; }

        public string FileName { get; set; }

        public string Comment { get; set; }

        public string Url { get; set; }
    }
}
