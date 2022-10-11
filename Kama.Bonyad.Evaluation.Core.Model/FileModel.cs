using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public abstract class FileModel : ModelGuID
    {
        public override string ToString() => FileName;

        public string FileName { get; set; }

        public string Comment { get; set; }

        public byte[] Data { get; set; }

        public Int64 DataLength { get; set; }
    }
}