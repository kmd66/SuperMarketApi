using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public abstract class Model
    {
        public int Total { get; set; }

        public long ID { get; set; }

        public Guid GuID { get; set; }

        public bool IsNew => ID == 0;
    }
}