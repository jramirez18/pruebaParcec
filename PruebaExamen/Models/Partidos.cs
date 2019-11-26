namespace PruebaExamen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partidos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPartido { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEquipo { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? fechaCreacion { get; set; }

        [Display(Name = "Goles marcados")]
        public int? golesMarcados { get; set; }

        [Display(Name = "Goles recibidos")]
        public int? golesRecibidos { get; set; }

        [StringLength(50)]
        [Display(Name = "Resultado")]
        public string resultado { get; set; }

        public virtual Equipos Equipos { get; set; }
    }
}
