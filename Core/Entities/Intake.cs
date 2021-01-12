using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Intake : BaseEntity
    {
        public int Energy { get; set; }
        public double Fat { get; set; }
        public double Saturates { get; set; }
        public double Sugars { get; set; }
        public double Salt { get; set; }
    }
}
