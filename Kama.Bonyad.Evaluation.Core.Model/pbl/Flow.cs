using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Flow : Flow<DocState>
    {
    }
    public class Flow<TDocState> : Model
    {
        public int DocumentID { get; set; }

        public Guid FromUserID { get; set; }

        public Guid? ToUserID { get; set; }

        public TDocState FromDocState { get; set; }

        public Guid FromPositionID { get; set; }

        public Guid ToPositionID { get; set; }

        public DateTime? Date { get; set; }

        public string FromUserFullName { get; set; }

        public Organization.Core.Model.EvaluationPositionType FromUserPositionType { get; set; }

        public Organization.Core.Model.EvaluationPositionType ToUserPositionType { get; set; }

        public TDocState ToDocState { get; set; }

        public SendType SendType { get; set; }

        public string Comment { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime? ActionDate { get; set; }

        public bool IsRead { get; set; }

        public string ToUserFullName { get; set; }

        public string Username { get; set; }

        public Flow<TDocState> ShallowCopy()
        {
            return (Flow<TDocState>)this.MemberwiseClone();
        }
    }
}
