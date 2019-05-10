using System;
using System.Collections.Generic;

namespace WhistApi.Models
{
    public partial class Bruger
    {
        public int Id { get; set; }
        public string Brugernavn { get; set; }
        public string Adgangskode { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Mail { get; set; }
    }
}
