using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Vegan, Vegetarian, Gluten-Free, etc

namespace Core.Entities
{
    public class Diet : BaseEntity, IEquatable<Diet>
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public bool Equals(Diet other)
        {
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Diet objAsDiet = obj as Diet;
            if (objAsDiet == null) return false;
            else return Equals(obj as Diet);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
