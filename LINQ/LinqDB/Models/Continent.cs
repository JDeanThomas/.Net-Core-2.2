using System;
using System.Collections.Generic;

namespace LinqDB.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Country = new HashSet<Country>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Country { get; set; }
    }
}
