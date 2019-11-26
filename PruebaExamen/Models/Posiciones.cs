namespace PruebaExamen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posiciones
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPosicion { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEquipo { get; set; }

        [Display(Name = "PJ")]
        public int? partidosJugados { get; set; }

        [Display(Name = "PG")]
        public int? partidosGanados { get; set; }

        [Display(Name = "PE")]
        public int? partidosEmpatados { get; set; }

        [Display(Name = "PP")]
        public int? partidosPerdidos { get; set; }

        [Display(Name = "GF")]
        public int? golesFavor { get; set; }

        [Display(Name = "GC")]
        public int? golesContra { get; set; }

        [Display(Name = "DC")]
        public int? diferenciaGoles { get; set; }

        [Display(Name = "P")]
        public int? puntosAcumulados { get; set; }

        public virtual Equipos Equipos { get; set; }
    }
}
