using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Cw_2.Models
{
    [XmlType(Namespace = "Student")]
    public class Student //: IEqualityComparer<Student>
    {

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Index { get; set; }
        public string Birth_Date { get; set; }
        public string Mother_Name { get; set; }
        public string Father_Name { get; set; }
        public Studies Studies_Info { get; set; }

        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj as Student);
        //}


        public override string ToString()
        {
            return Index + " " + First_Name + " " + Last_Name;
        }
        public String GetIndex()
        {
            return Index;
        }

        public bool Equals([AllowNull] Student other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Index.Equals(other.Index);
        }

        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else
            {
                    return x.Index.Equals(y.Index);
            }
          
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
