using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpilService.Models
{
    public class Runde
    {
        public int Id { get; set; }
        public int SpilId { get; set; }
        public int RundeNr { get; set; }
        public int Melder { get; set; }
        public int Melding { get; set; }
        public int PlusId { get; set; }
        public int Makker { get; set; }
        public bool Vundet { get; set; }
        public double Beloeb { get; set; }
        public int Spiller1 { get; set; }
        public int Spiller2 { get; set; }
        public int Spiller3 { get; set; }
        public int Spiller4 { get; set; }
    }
}
