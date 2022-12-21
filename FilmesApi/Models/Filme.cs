using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo titulo e obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor e obrigatorio")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "o genero nao pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A duracao deve ter no minimo 1 e no maximo 600 minutos")]
        public int Duracao { get; set; }
        public int? ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessaos { get; set; }
    }
}
