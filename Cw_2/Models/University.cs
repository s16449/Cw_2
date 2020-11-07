using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw_2.Models
{
    public class University
    {
        public University()
        {
            Students = new HashSet<Student>();
            Active_Studies = new HashSet<ActiveStudies>();
            Created_At = DateTime.Now.ToString("yyyy-mm-dd");

        }

        public string Author { get; set; }
        public HashSet<Student> Students { get; set; }

        public String Created_At { get; set; }
        public HashSet<ActiveStudies> Active_Studies { get; set; }


    }
}
