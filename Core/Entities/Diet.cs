using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Vegan, Vegetarian, Gluten-Free, etc

namespace Core.Entities
{
    public class Diet : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
