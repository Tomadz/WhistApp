using System;
using System.Collections.Generic;

namespace WhistApi.Models
{
    public partial class Regelsæt
    {
        public Regelsæt()
        {
            Spil = new HashSet<Spil>();
        }

        public int Id { get; set; }
        public decimal Base { get; set; }
        public decimal MultiplyTab { get; set; }
        public decimal BaseVip { get; set; }

        public virtual ICollection<Spil> Spil { get; set; }
    }
}
