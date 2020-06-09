using System;
using System.Collections.Generic;
using System.Text;

namespace TestReflextionAttributes.SP
{
    public class MetadataObject
    {
        public string Name;
        public string SPName;
        public string SPDescription;
        public List<MetadataProperty> Properties;
    }

    public class MetadataProperty
    {
        public string Name;
        public string SPName;
        public string SPDisplayName;
    }
}
