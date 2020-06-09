using System;
using System.Collections.Generic;
using System.Text;

namespace TestReflextionAttributes.SP
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class ListAttrib : Attribute
    {
        public string Name;
        public string Description;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ListItemAttrib : Attribute
    {
        public string Name;
        public string DisplayName;
        public string DataType;
        public bool Key;
    }


}
