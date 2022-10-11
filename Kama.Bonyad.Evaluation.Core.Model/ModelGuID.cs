using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public abstract class ModelGuID
    {
        public int Total { get; set; }
        public Guid ID { get; set; }
        public bool IsNew => ID == Guid.Empty;
    }
}