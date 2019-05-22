using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpilService.Models
{
    public class Regelsæt
    {
        public int Id { get; set; }
        public double Base { get; set; }
        public double MultiplyTab { get; set; }
        public double BaseVip { get; set; }
        public List<Plus> Pluser { get; set; }
    }
}
