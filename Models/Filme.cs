using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Models
{
    public class Filme
    {
        [Key] //chave primária
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O Título precisa ter mais de 3 caractéres.")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido.")]
        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório.")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\W-]*$", ErrorMessage = "Genero em formato inválido")] //a primeira letra é de A-Z maíuscula, e o restante de a-z minúscula, usando acentos
        [Required(ErrorMessage = "O campo Genero é obrigatório.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O Genero precisa ter mais de 3 caractéres.")]
        public string Genero { get; set; }

        [Range(1,1000, ErrorMessage = "O valor deve estar entre 1 e 1000")]
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Display(Name = "Avaliação")]
        [Required(ErrorMessage = "O campo Avaliação é obrigatório.")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Avaliação em formato inválido")]
        public int Avaliacao { get; set; }
    }
}
