using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CsiMediaTechTest.Models
{
    public class ChangeLog
    {
        public List<Version> Versions { get; set; } = new List<Version>();
    }
}