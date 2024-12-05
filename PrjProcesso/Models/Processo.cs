using System;
using System.ComponentModel.DataAnnotations;

namespace PrjProcesso.Models
{
    public class Processo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(300)]
        public string NomeProcesso { get; set; }

        [Required]
        public string NPU { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataVisualizacao { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }

        [Required]
        [StringLength(300)]
        public string Municipio { get; set; }
    }
}
