using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
   public class Action:Model
    {
        public Guid ControllerID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
