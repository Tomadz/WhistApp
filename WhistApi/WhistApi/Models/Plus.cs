using System;
using System.Collections.Generic;

namespace WhistApi.Models
{
    public partial class Plus
    {
        public Plus()
        {
            Runder = new HashSet<Runder>();
        }

        public int Id { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<Runder> Runder { get; set; }
    }
}
