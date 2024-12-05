using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PrjProcesso.ViewModels
{
    public class ProcessoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do processo é obrigatório.")]
        [StringLength(300, ErrorMessage = "O nome do processo deve ter no máximo 300 caracteres.")]
        [Display(Name = "Nome do Processo")]
        public string NomeProcesso { get; set; }

        [Required(ErrorMessage = "O NPU é obrigatório.")]
        [RegularExpression(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$",
        ErrorMessage = "O NPU deve estar neste formato 1111111-11.1111.1.11.1111.")]
        public string NPU { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Visualização")]
        public DateTime? DataVisualizacao { get; set; }

        [Required(ErrorMessage = "O estado (UF) é obrigatório.")]
        [StringLength(2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O município é obrigatório.")]
        [StringLength(300, ErrorMessage = "O município deve ter no máximo 300 caracteres.")]
        [Display(Name = "Município")]
        public string Municipio { get; set; }
    }
}
