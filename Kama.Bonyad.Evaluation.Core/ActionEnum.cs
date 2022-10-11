using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core
{
    public class LogValueAttribute : Attribute
    {
        public short Number { get; }

        public string Name { get; }

        public string Title { get; }

        public LogValueAttribute(short number, string title, string name = null)
        {
            this.Number = number;
            this.Name = name;
            this.Title = title;
        }
    }
}
