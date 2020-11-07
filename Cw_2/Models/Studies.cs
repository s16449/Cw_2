using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw_2.Models
{
    [Serializable]
    public class Studies
    {
        [XmlAttribute]
        public string Studies_Name { get; set; }
        public string Studies_Mode { get; set; }
    }
}
