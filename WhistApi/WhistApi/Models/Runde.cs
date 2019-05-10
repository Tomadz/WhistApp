using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhistApi.Models
{
    public class Runde
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SpilId { get; set; }
        [Required]
        public int RundeNr { get; set; }
        [Required]
        public int Melder { get; set; }
        [Required]
        public int Melding { get; set; }
        [Required]
        public int PlusId { get; set; }
        [Required]
        public int Makker { get; set; }
        [Required]
        public bool Vundet { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Beloeb { get; set; }
        [Required]
        public int Spiller1 { get; set; }
        [Required]
        public int Spiller2 { get; set; }
        [Required]
        public int Spiller3 { get; set; }
        [Required]
        public int Spiller4 { get; set; }
    }
}