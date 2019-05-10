using System;
using System.Collections.Generic;

namespace WhistApi.Models
{
    public partial class Runder
    {
        public int Id { get; set; }
        public int? SpilId { get; set; }
        public int RundeNr { get; set; }
        public int Melder { get; set; }
        public int Melding { get; set; }
        public int? PlusId { get; set; }
        public int? Makker { get; set; }
        public bool Vundet { get; set; }
        public decimal Beløb { get; set; }
        public int Spiller1 { get; set; }
        public int Spiller2 { get; set; }
        public int Spiller3 { get; set; }
        public int Spiller4 { get; set; }

        public virtual Plus Plus { get; set; }
        public virtual Spil Spil { get; set; }
    }
}
