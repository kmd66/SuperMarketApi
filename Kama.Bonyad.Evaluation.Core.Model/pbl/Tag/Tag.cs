﻿
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class Tag : Model
    {
        public int TagID { get; set; }
        public long ItemID { get; set; }
        public string TagName { get; set; }
    }
}
