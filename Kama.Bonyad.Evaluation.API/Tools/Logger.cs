﻿namespace Kama.Bonyad.Evaluation.API.Tools
{
    public class Logger : AppCore.EventLogger.WindowsEventLogger, Core.IEventLogger
    {
        public Logger()
            : base("Kama.Bonyad.Evaluation")
        {
        }
    }
}