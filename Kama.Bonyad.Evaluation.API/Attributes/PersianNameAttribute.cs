using System;

namespace Kama.Bonyad.Evaluation.API.Attributes
{
    public class PersianNameAttribute : Attribute
    {
        public string Name;

        public PersianNameAttribute(string name)
        {
            Name = name;
        }
    }
}