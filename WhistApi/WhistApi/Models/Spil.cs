using System;
using System.Collections.Generic;

namespace WhistApi.Models
{
    public partial class Spil
    {
        public Spil()
        {
            Runder = new HashSet<Runder>();
        }

        public int Id { get; set; }
        public int? RegelsætId { get; set; }

        public virtual Regelsæt Regelsæt { get; set; }
        public virtual ICollection<Runder> Runder { get; set; }
    }
}
