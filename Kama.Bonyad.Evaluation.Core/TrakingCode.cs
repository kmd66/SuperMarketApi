using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core
{
    public sealed class TrakingCode
    {
        private TrakingCode()
        {

        }

        readonly static Lazy<TrakingCode> _instance = new Lazy<TrakingCode>(() => new TrakingCode());

        public static TrakingCode Instance => _instance.Value;

        public string Generate(string prefix = "")
        {
            var hash = Guid.NewGuid().GetHashCode();
            prefix += hash < 1 ? "1" : "2";
            return prefix + Math.Abs(hash).ToString(); 
        } 
    }
}
