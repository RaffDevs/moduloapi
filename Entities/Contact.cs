using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moduloapi.Entities
{
    public class Contact
    {
        public int Id { get; set;}

        public string Name { get; set;}

        public string Telephone { get; set; }

        public bool Active { get; set; }
    }
}