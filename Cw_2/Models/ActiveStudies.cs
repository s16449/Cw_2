using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cw_2.Models
{
    public class ActiveStudies : IEqualityComparer<ActiveStudies>
    {
        public string Name_of_Studies { get; set; }
        public int Number_Of_Students { get; set; }

        //public bool Equals([AllowNull] ActiveStudies other)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Equals([AllowNull] ActiveStudies x, [AllowNull] ActiveStudies y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.Name_of_Studies.Equals(y.Name_of_Studies);
            }
        }

        public int GetHashCode([DisallowNull] ActiveStudies obj)
        {
            return obj.GetHashCode();
        }
    }
}
